using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using project_demo.Controllers;
using project_demo.Model.DTO;
using project_demo.Model;
using Microsoft.Extensions.Logging;
using project_demo.Repository;

namespace InventorySystemTest
{
    [TestFixture]
    internal class ProductControllerTest
    {
        private Mock<Imainrepository> _mockRepository;
        private Mock<ILogger<ProductController>> _mockLogger;
        private ProductController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<Imainrepository>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            _controller = new ProductController(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public void NewProduct_ReturnsOkResult_WhenProductIsAdded()
        {
            // Arrange
            var newProductDto = new newproductDTO
            {
                ProductName = "Test Product",
                product_detail = "Test Detail",
                Category_Name = "Test Category",
                category_id = 1,
                amount = 100
            };

            _mockRepository.Setup(repo => repo.NewProduct(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                           .Returns(new Product());

            // Act
            var result = _controller.NewProduct(newProductDto);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        

        [Test]
        public void UpdateStockPriceById_ReturnsBadRequest_WhenProductNotFound()
        {
            // Arrange
            var productId = 1;
            var newPrice = 150.0f;

            _mockRepository.Setup(repo => repo.UpdatePriceById(productId, newPrice)).Returns(false);

            // Act
            var result = _controller.UpdateStockPriceById(productId, newPrice);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }


        [Test]
        public async Task SetMinQuantity_ReturnsOkResult_WhenMinQuantityIsUpdated()
        {
            // Arrange
            var productName = "Test Product";
            var minQuantity = 10;

            _mockRepository.Setup(repo => repo.SetMinQuantityAsync(productName, minQuantity)).ReturnsAsync(true);

            // Act
            var result = await _controller.SetMinQuantity(productName, minQuantity);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task SetMinQuantity_ReturnsBadRequest_WhenProductNotFound()
        {
            // Arrange
            var productName = "Test Product";
            var minQuantity = 10;

            _mockRepository.Setup(repo => repo.SetMinQuantityAsync(productName, minQuantity)).ReturnsAsync(false);

            // Act
            var result = await _controller.SetMinQuantity(productName, minQuantity);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task SetMaxQuantity_ReturnsOkResult_WhenMaxQuantityIsUpdated()
        {
            // Arrange
            var productName = "Test Product";
            var maxQuantity = 50;

            _mockRepository.Setup(repo => repo.SetMaxQuantityAsync(productName, maxQuantity)).ReturnsAsync(true);

            // Act
            var result = await _controller.SetMaxQuantity(productName, maxQuantity);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task SetMaxQuantity_ReturnsBadRequest_WhenProductNotFound()
        {
            // Arrange
            var productName = "Test Product";
            var maxQuantity = 50;

            _mockRepository.Setup(repo => repo.SetMaxQuantityAsync(productName, maxQuantity)).ReturnsAsync(false);

            // Act
            var result = await _controller.SetMaxQuantity(productName, maxQuantity);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task AddCategory_ReturnsCreatedAtActionResult_WhenCategoryIsAdded()
        {
            // Arrange
            var category = new Category { category_id = 1, category_Name = "Test Category" };

            _mockRepository.Setup(repo => repo.AddCategoryAsync(category)).ReturnsAsync(category);

            // Act
            var result = await _controller.AddCategory(category);

            // Assert
            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
        }

        [Test]
        public async Task GetCategoryById_ReturnsOkResult_WhenCategoryIsFound()
        {
            // Arrange
            var categoryId = 1;
            var category = new Category { category_id = categoryId, category_Name = "Test Category" };

            _mockRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync(category);

            // Act
            var result = await _controller.GetCategoryById(categoryId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetCategoryById_ReturnsNotFound_WhenCategoryNotFound()
        {
            // Arrange
            var categoryId = 1;

            _mockRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync((Category)null);

            // Act
            var result = await _controller.GetCategoryById(categoryId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task GetAllCategories_ReturnsOkResult_WithListOfCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { category_id = 1, category_Name = "Category 1" },
                new Category { category_id = 2, category_Name = "Category 2" }
            };

            _mockRepository.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await _controller.GetAllCategories();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task UpdateCategory_ReturnsOkResult_WhenCategoryIsUpdated()
        {
            // Arrange
            var categoryId = 1;
            var category = new Category { category_id = categoryId, category_Name = "Updated Category" };

            _mockRepository.Setup(repo => repo.UpdateCategoryAsync(category)).ReturnsAsync(category);

            // Act
            var result = await _controller.UpdateCategory(categoryId, category);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task UpdateCategory_ReturnsBadRequest_WhenCategoryIdMismatch()
        {
            // Arrange
            var categoryId = 1;
            var category = new Category { category_id = 2, category_Name = "Updated Category" };

            // Act
            var result = await _controller.UpdateCategory(categoryId, category);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public async Task DeleteCategory_ReturnsNoContent_WhenCategoryIsDeleted()
        {
            // Arrange
            var categoryId = 1;

            _mockRepository.Setup(repo => repo.DeleteCategoryAsync(categoryId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteCategory(categoryId);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task DeleteCategory_ReturnsNotFound_WhenCategoryNotFound()
        {
            // Arrange
            var categoryId = 1;

            _mockRepository.Setup(repo => repo.DeleteCategoryAsync(categoryId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteCategory(categoryId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}

//[Test]
//public void UpdateStockPriceById_ReturnsOkResult_WhenPriceIsUpdated()
//{
//    var productId = 1;
//    var newPrice = 150.0f;
//    // Arrange.Setup(repo => repo.UpdatePriceById(productId, newPrice)).Returns(true);

//    // Act
//    var result = _controller.UpdateStockPriceById(productId, newPrice);

//    // Assert
//    Assert.That(result, Is.InstanceOf<OkObjectResult>());
//}