//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using project_demo.Repository;
//using project_demo.Model.DTO;

//using System.Threading.Tasks;

//namespace project_demo.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReturnsController : ControllerBase
//    {
//        private readonly IReturnRepository _returnRepository;

//        public ReturnsController(IReturnRepository returnRepository)
//        {
//            _returnRepository = returnRepository;
//        }

//        [HttpPost("RequestReturn")]
//        public async Task<IActionResult> RequestReturn([FromBody] ReturnRequestDto returnRequest)
//        {
//            var result = await _returnRepository.RequestReturn(returnRequest);
//            if (!result) return BadRequest("Failed to request return");
//            return Ok(new { message = "Return requested successfully" });
//        }

//        [HttpPost("ProcessRefund/{returnId}")]
//        public async Task<IActionResult> ProcessRefund(int returnId)
//        {
//            var result = await _returnRepository.ProcessRefund(returnId);
//            if (!result) return BadRequest("Failed to process refund");
//            return Ok(new { message = "Refund processed successfully" });
//        }
//    }
//}