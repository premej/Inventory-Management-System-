using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project_demo.Repository;
using project_demo.Model.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using project_demo.Model;

namespace project_demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Imainrepository _mainRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(Imainrepository mainRepository, ILogger<ProductController> logger)
        {
            _mainRepository = mainRepository;
            _logger = logger;
        }

        [HttpPost("NewProduct")]
        public IActionResult NewProduct([FromBody] newproductDTO pd)
        {
            _logger.LogInformation("Adding new product: {@Product}", pd);
            var res = _mainRepository.NewProduct(pd.ProductName, pd.product_detail, pd.Category_Name, pd.category_id, pd.Category_Name, pd.amount);
            _logger.LogInformation("New product added successfully: {@Product}", res);
            return Ok(new { message = "New product added successfully" });
        }

        [HttpPut("UpdateStockPriceById")]
        public IActionResult UpdateStockPriceById([FromQuery] int productId, [FromQuery] float newPrice)
        {
            _logger.LogInformation("Updating stock price for product ID {ProductId} to {NewPrice}", productId, newPrice);
            var result = _mainRepository.UpdatePriceById(productId, newPrice);
            if (result)
            {
                _logger.LogInformation("Stock price updated successfully for product ID {ProductId}", productId);
                return Ok(new { message = "Stock price updated successfully" });
            }
            _logger.LogWarning("Product not found for ID {ProductId}", productId);
            return BadRequest("Product not found");
        }

        [HttpPut("SetMinQuantity")]
        public async Task<IActionResult> SetMinQuantity([FromQuery] string productName, [FromQuery] int minQuantity)
        {
            _logger.LogInformation("Setting minimum quantity for product {ProductName} to {MinQuantity}", productName, minQuantity);
            var result = await _mainRepository.SetMinQuantityAsync(productName, minQuantity);
            if (result)
            {
                _logger.LogInformation("Minimum quantity updated successfully for product {ProductName}", productName);
                return Ok(new { message = "Minimum quantity updated successfully", productName, minQuantity });
            }
            _logger.LogWarning("Product not found: {ProductName}", productName);
            return BadRequest("Product not found");
        }

        [HttpPut("SetMaxQuantity")]
        public async Task<IActionResult> SetMaxQuantity([FromQuery] string productName, [FromQuery] int maxQuantity)
        {
            _logger.LogInformation("Setting maximum quantity for product {ProductName} to {MaxQuantity}", productName, maxQuantity);
            var result = await _mainRepository.SetMaxQuantityAsync(productName, maxQuantity);
            if (result)
            {
                _logger.LogInformation("Maximum quantity updated successfully for product {ProductName}", productName);
                return Ok(new { message = "Maximum quantity updated successfully", productName, maxQuantity });
            }
            _logger.LogWarning("Product not found: {ProductName}", productName);
            return BadRequest("Product not found");
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            _logger.LogInformation("Adding new category: {@Category}", category);
            var newCategory = await _mainRepository.AddCategoryAsync(category);
            _logger.LogInformation("New category added successfully: {@Category}", newCategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.category_id }, newCategory);
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            _logger.LogInformation("Retrieving category by ID: {CategoryId}", id);
            var category = await _mainRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                _logger.LogWarning("Category not found for ID: {CategoryId}", id);
                return NotFound();
            }
            _logger.LogInformation("Category retrieved successfully: {@Category}", category);
            return Ok(category);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            _logger.LogInformation("Retrieving all categories");
            var categories = await _mainRepository.GetAllCategoriesAsync();
            _logger.LogInformation("Categories retrieved successfully: {@Categories}", categories);
            return Ok(categories);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.category_id)
            {
                _logger.LogWarning("Category ID mismatch: {CategoryId} != {Category.category_id}", id, category.category_id);
                return BadRequest();
            }

            _logger.LogInformation("Updating category: {@Category}", category);
            var updatedCategory = await _mainRepository.UpdateCategoryAsync(category);
            _logger.LogInformation("Category updated successfully: {@Category}", updatedCategory);
            return Ok(updatedCategory);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _logger.LogInformation("Deleting category by ID: {CategoryId}", id);
            var result = await _mainRepository.DeleteCategoryAsync(id);
            if (!result)
            {
                _logger.LogWarning("Category not found for ID: {CategoryId}", id);
                return NotFound();
            }
            _logger.LogInformation("Category deleted successfully for ID: {CategoryId}", id);
            return NoContent();
        }
    }
}
