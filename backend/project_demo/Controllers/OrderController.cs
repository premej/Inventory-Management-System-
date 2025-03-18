//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using project_demo.Repository;
//using project_demo.Model;
//using project_demo.Model.DTO;
//using System.Threading.Tasks;

//namespace project_demo.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly IOrderRepository _orderRepository;

//        public OrdersController(IOrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }

//        [HttpPost("PlaceOrder")]
//        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto order)
//        {
//            var result = await _orderRepository.PlaceOrder(order);
//            if (!result) return BadRequest("Failed to place order");
//            return Ok(new { message = "Order placed successfully" });
//        }

//        [HttpGet("GetOrder/{orderId}")]
//        public async Task<IActionResult> GetOrder(int orderId)
//        {
//            var order = await _orderRepository.GetOrderById(orderId);
//            if (order == null) return NotFound("Order not found");
//            return Ok(order);
//        }

//        [HttpPut("UpdateStatus/{orderId}")]
//        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
//        {
//            var result = await _orderRepository.UpdateOrderStatus(orderId, status);
//            if (!result) return BadRequest("Failed to update order status");
//            return Ok(new { message = "Order status updated successfully" });
//        }
//    }
//}
