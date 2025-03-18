using Microsoft.AspNetCore.Mvc;
using project_demo.Repository;
using project_demo.Model.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace project_demo.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly Imainrepository _mainRepository;

        public SalesController(Imainrepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        [HttpPost("NewSale")]
        //[Authorize]
        public IActionResult newsale([FromBody] newsaleDTO saledto)
        {

            var res = _mainRepository.NewSaleAsync(saledto.customer_id, saledto.customername, saledto.productid, saledto.quantity);
            if (res == "Customer does not exist in the database. Please add the customer to continue.")
            {
                return Ok(new { message = res });
            }
            if (res == "The mentioned product is not in the database.")
            {
                return Ok(new { message = res });
            }
            if (res == "insufficent quantity")
            {
                return Ok(new { message = "insufficient quantity" });
            }

            return Ok(new { message = "sale transaction is  successful" });
        }
        [HttpGet("SalesHistory")]
        public IActionResult SalesHistory()
        {
            var result = _mainRepository.GetAllSalesHistory();
            return Ok(result);
        }

        [HttpGet("Customers")]
        public IActionResult GetAllCustomers()
        {
            var result = _mainRepository.GetAllCustomers();
            return Ok(result);
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customer)
        {
            var res = await _mainRepository.AddCustomerAsync(customer);
            if (!res)
            {
                return BadRequest("Failed to add customer");
            }

            return Ok(new { message = "Customer added successfully" });
        }
        [HttpPut("UpdateCustomer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerDto customer)
        {
            var res = await _mainRepository.UpdateCustomerAsync(customerId, customer);
            if (!res)
            {
                return NotFound("Customer not found");
            }

            return Ok(new { message = "Customer updated successfully" });
        }
        [HttpGet("SalesReport")]
        public IActionResult GetSalesReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string period)
        {
            var result = _mainRepository.GetSalesReport(startDate, endDate, period);
            return Ok(result);
        }
        [HttpDelete("DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var res = await _mainRepository.DeleteCustomerAsync(customerId);
            if (!res)
            {
                return NotFound("Customer not found");
            }

            return Ok(new { message = "Customer deleted successfully" });
        }
        //[HttpGet("SalesHistory")]
        //public IActionResult SalesHistory()
        //{
        //    var result = _mainRepository.GetSalesHistory();
        //    return Ok(result);
        //}

        //[HttpGet("Reports")]
        //public IActionResult Reports()
        //{
        //    var result = _mainRepository.GenerateSalesReports();
        //    return Ok(result);
        //}
    }
}