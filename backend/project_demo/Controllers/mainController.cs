//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using project_demo.Data;
//using project_demo.Model;
//using project_demo.Model.DTO;
//using project_demo.Repository;

//namespace project_demo.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class mainController : ControllerBase
//    {
//        private readonly AppDbContext _context;
//        private readonly Imainrepository _mainrepository;

//        public mainController(AppDbContext context, Imainrepository mainrepo)
//        {
//            _context = context;
//            _mainrepository = mainrepo;

//        }

//        //add a new purchase i.e invoice
//        [HttpPost("NewPurchase")]
//        //[Authorize(Roles ="USer")]
//        public async Task<IActionResult> newpurchase([FromBody] new_purchaseDTO prch)

//        {

//            var res = _mainrepository.Newpurchaseasync(prch.user_id, prch.productid, prch.Invoiceno, prch.Quantity, prch.suppliername);
//            if (res == null)
//            {
//                return BadRequest("product does not exist at first add product");
//            }

//            return Ok(new { message = "New invoice added successfully" });
//        }

//        //Add a new product
//        [HttpPost("Newproduct")]
//        //[Authorize(Roles ="User")]
//        public IActionResult newProduct([FromBody] newproductDTO pd)
//        {
//            var res = _mainrepository.NewProduct(pd.ProductName, pd.product_detail, pd.Category_Name, pd.category_id, pd.Category_Name, pd.amount);
//            return Ok(new { message = "new product added successfully" });
//        }
//        [HttpPost("SetMinQuantity")]
//        public async Task<IActionResult> SetMinQuantity([FromQuery] string productName, [FromQuery] int minQuantity)
//        {
//            var res = await _mainrepository.SetMinQuantityAsync(productName, minQuantity);
//            if (res)
//            {
//                return Ok("Minimum quantity updated successfully");
//            }
//            return BadRequest("Product not found");
//        }

//        // Set maximum quantity for a product
//        [HttpPost("SetMaxQuantity")]
//        public async Task<IActionResult> SetMaxQuantity([FromQuery] string productName, [FromQuery] int maxQuantity)
//        {
//            var res = await _mainrepository.SetMaxQuantityAsync(productName, maxQuantity);
//            if (res)
//            {
//                return Ok("Maximum quantity updated successfully");
//            }
//            return BadRequest("Product not found");
//        }
//        //to sell a item
//        [HttpPost("NewSale")]
//        //[Authorize]
//        public IActionResult newsale([FromBody] newsaleDTO saledto)
//        {

//            var res = _mainrepository.NewSaleAsync(saledto.customer_id, saledto.customername, saledto.productid, saledto.quantity);
//            if (res == "insufficent quantity")
//            {
//                return Ok(new { message = "insufficient quantity" });
//            }

//            return Ok(new { message = "sale transaction is  successful" });
//        }

//        //to see the inventory size
//        [HttpGet("review_inventory")]
//        //[Authorize]
//        public async Task<IActionResult> GetStockdetail()
//        {

//            // var res =   _mainrepository.Review_inventory();

//            var res1 = (from p in _context.stocks
//                        join q in _context.products on p.ProductId equals q.ProductId
//                        select new stockshow
//                        {
//                            ProductId = q.ProductId,
//                            ProductName = q.ProductName,
//                            quantity = p.Quantity,
//                            minquantity = p.min_Quantity,
//                            maxquantity = p.max_Quantity
//                        });



//            //return  inventory Dto to client
//            return Ok(res1);
//        }

//        //get transictions of user by userId
//        [HttpGet("usertransiction")]

//        public ActionResult<dynamic> usertransitions()
//        {

//            var transictions = _mainrepository.USerTransiction();

//            return Ok(transictions);
//        }
//        [HttpGet("get_min_quantity")]
//        public IActionResult get_min_quantity()
//        {

//            var res = _mainrepository.Min_Quantity();
//            return Ok(res);

//        }
//        [HttpGet("get_max_quantity")]
//        public IActionResult get_max_quantity()
//        {

//            var res = _mainrepository.Max_Quantity();
//            return Ok(res);
//        }
//        [HttpPost("update stock price by id")]
//        public IActionResult Update_price_by_id([FromQuery] int product_id, [FromQuery] float new_price)
//        {

//            var res = _mainrepository.UpdatePriceById(product_id, new_price);
//            if (res)
//            {
//                return Ok("NEW PRICE UPDATED SUCCESSFULLY");
//            }
//            return BadRequest("PRODUCT NOT FOUND");

//        }



//    }
//}
