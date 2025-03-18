//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using project_demo.Repository;
//using System;
//using System.Collections.Generic;

//namespace project_demo.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WeeklySalesReportController : ControllerBase
//    {
//        private readonly IReportRepository _reportRepository;

//        public WeeklySalesReportController(IReportRepository reportRepository)
//        {
//            _reportRepository = reportRepository;
//        }

//        [HttpGet("WeeklySales")]
//        public IActionResult GetWeeklySalesReport()
//        {
//            var report = _reportRepository.GenerateWeeklySalesReport();
//            return Ok(report);
//        }
//    }
//}