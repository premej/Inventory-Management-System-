using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_demo.Repository;
using System.Threading.Tasks;

namespace project_demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly Imainrepository _mainRepository;

        public TransactionController(Imainrepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        [HttpGet("usertransaction")]

        public ActionResult<dynamic> usertransactions()
        {

            var transactions = _mainRepository.UserTransaction();

            return Ok(transactions);
        }
        [HttpGet("ProductWiseTransactions/{productId}")]
        public IActionResult GetProductWiseTransactions(int productId)
        {
            var result = _mainRepository.GetProductWiseTransactions(productId);
            if (result.Count==0)
            {
                return BadRequest("No Transactions available with id " + productId);
            }
            return Ok(result);
        }
        //[HttpGet("DayToDaySpend")]
        //public IActionResult DayToDaySpend()
        //{
        //    var result = _mainRepository.GetDayToDaySpend();
        //    return Ok(result);
        //}

        //[HttpGet("WeeklySpendReports")]
        //public IActionResult WeeklySpendReports()
        //{
        //    var result = _mainRepository.GetWeeklySpendReports();
        //    return Ok(result);
        //}
    }
}