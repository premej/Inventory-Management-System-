using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_demo.Data;
using project_demo.Model;
using project_demo.Repository;
using System.Threading.Tasks;

namespace project_demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Imainrepository _mainRepository;

        public StockController(Imainrepository mainRepository, AppDbContext context)
        {
            _mainRepository = mainRepository;
            _context = context;
        }

        [HttpGet("review_inventory")]
        //[Authorize]
        public async Task<IActionResult> GetStockdetail()
        {

            // var res =   _mainrepository.Review_inventory();

            var res1 = (from p in _context.stocks
                        join q in _context.products on p.ProductId equals q.ProductId
                        select new stockshow
                        {
                            ProductId = q.ProductId,
                            ProductName = q.ProductName,
                            quantity = p.Quantity,
                            Price = q.price,
                            minquantity = p.min_Quantity,
                            maxquantity = p.max_Quantity
                        });



            //return  inventory Dto to client
            return Ok(res1);
        }

        [HttpGet("GetUnderStockProducts")]
        public IActionResult GetMinQuantity()
        {
            var result = _mainRepository.GetProductsBelowMinQuantity();
            return Ok(result);
        }

        [HttpGet("GetOverStockProducts")]
        public IActionResult GetMaxQuantity()
        {
            var result = _mainRepository.GetProductsAboveMaxQuantity();
            return Ok(result);
        }
        [HttpGet("GetOutOfStockProducts")]
        public async Task<IActionResult> GetOutOfStockProducts()
        {
            
            var products = await _mainRepository.GetOutOfStockProductsAsync();
            if (products == null || !products.Any())
            {
                
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("GetStockByProductId")]
        public async Task<IActionResult> GetStockByProductId([FromQuery] int productId)
        {
            var result = await _mainRepository.GetStockByProductIdAsync(productId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Product not found");
        }
    }
}