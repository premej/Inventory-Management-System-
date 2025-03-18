//using project_demo.Data;
//using project_demo.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using project_demo.Model.DTO;
//public class ReportRepository : IReportRepository
//{
//    private readonly AppDbContext _context;

//    public ReportRepository(AppDbContext context)
//    {
//        _context = context;
//    }

//    public List<SalesReportDto> GenerateSalesReport()
//    {
//        return _context.Orders
//            .GroupBy(o => o.ProductId)
//            .Select(g => new SalesReportDto
//            {
//                ProductId = g.Key,
//                TotalSales = g.Sum(o => o.Quantity),
//               // TotalRevenue = g.Sum(o => o.Quantity * o.Product.price)
//            }).ToList();
//    }

//    public List<StockReportDto> GenerateStockReport()
//    {
//        return _context.stocks.Select(s => new StockReportDto
//        {
//            ProductId = s.ProductId,
//            ProductName = s.Product.ProductName,
//            AvailableStock = s.Quantity
//        }).ToList();
//    }

//    public List<WeeklySalesReportDto> GenerateWeeklySalesReport()
//    {
//        DateTime lastWeek = DateTime.Now.AddDays(-7);

//        return _context.Orders
//            .Where(o => o.OrderDate >= lastWeek)
//            .GroupBy(o => new { o.ProductId, o.OrderDate.Date })
//            .Select(g => new WeeklySalesReportDto
//            {
//                ProductId = g.Key.ProductId,
//                Date = g.Key.Date,
//                TotalSales = g.Sum(o => o.Quantity),
//               // TotalRevenue = g.Sum(o => o.Quantity * o.Product.price)
//            }).OrderByDescending(r => r.Date).ToList();
//    }
//}