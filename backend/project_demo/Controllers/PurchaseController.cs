using Microsoft.AspNetCore.Mvc;
using project_demo.Repository;
using project_demo.Model.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace project_demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly Imainrepository _mainRepository;

        public PurchaseController(Imainrepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        [HttpPost("NewPurchase")]
        //[Authorize(Roles ="USer")]
        public async Task<IActionResult> newpurchase([FromBody] new_purchaseDTO prch)

        {

            var res = _mainRepository.Newpurchaseasync(prch.supplier_id, prch.productid, prch.Quantity, prch.suppliername);
            if (res == null)
            {
                return BadRequest(new { message = "Supplier or product does not exist in the database. Please add them to continue." });
            }

            return Ok(new { message = "New invoice added successfully" });
        }
        [HttpGet("PurchaseHistory")]
        public IActionResult PurchaseHistory()
        {
            var result = _mainRepository.GetAllPurchaseHistory();
            return Ok(result);
        }

        [HttpGet("Suppliers")]
        public IActionResult GetAllSuppliers()
        {
            var result = _mainRepository.GetAllSuppliers();
            return Ok(result);
        }


        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDto supplier)
        {
            var res = await _mainRepository.AddSupplierAsync(supplier);
            if (!res)
            {
                return BadRequest("Failed to add supplier");
            }

            return Ok(new { message = "Supplier added successfully" });
        }
        [HttpPut("UpdateSupplier/{supplierId}")]
        public async Task<IActionResult> UpdateSupplier(int supplierId, [FromBody] SupplierDto supplier)
        {
            var res = await _mainRepository.UpdateSupplierAsync(supplierId, supplier);
            if (!res)
            {
                return NotFound("Supplier not found");
            }

            return Ok(new { message = "Supplier updated successfully" });
        }
        
        [HttpGet("PurchaseReport")]
        public IActionResult GetPurchaseReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string period)
        {
            var result = _mainRepository.GetPurchaseReport(startDate, endDate, period);
            return Ok(result);
        }
        [HttpDelete("DeleteSupplier/{supplierId}")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            var res = await _mainRepository.DeleteSupplierAsync(supplierId);
            if (!res)
            {
                return NotFound("Supplier not found");
            }

            return Ok(new { message = "Supplier deleted successfully" });
        }
        //[HttpGet("Reports")]
        //public IActionResult Reports()
        //{
        //    var result = _mainRepository.GeneratePurchaseReports();
        //    return Ok(result);
        //}
    }
}