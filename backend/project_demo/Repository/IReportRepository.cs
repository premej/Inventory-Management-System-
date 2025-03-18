using System.Collections.Generic;
using project_demo.Model.DTO;

public interface IReportRepository
{
    List<SalesReportDto> GenerateSalesReport();
    List<StockReportDto> GenerateStockReport();
    List<WeeklySalesReportDto> GenerateWeeklySalesReport(); // Add this method
}