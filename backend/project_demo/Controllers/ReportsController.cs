//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using project_demo.Repository;

//namespace project_demo.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReportsController : ControllerBase
//    {
//        private readonly IReportRepository _reportRepository;

//        public ReportsController(IReportRepository reportRepository)
//        {
//            _reportRepository = reportRepository;
//        }

//        [HttpGet("SalesReport")]
//        public IActionResult GetSalesReport()
//        {
//            var report = _reportRepository.GenerateSalesReport();
//            return Ok(report);
//        }

//        [HttpGet("StockReport")]
//        public IActionResult GetStockReport()
//        {
//            var report = _reportRepository.GenerateStockReport();
//            return Ok(report);
//        }
//    }
//}
