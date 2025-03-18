using System;

namespace project_demo.Model.DTO
{
    public class WeeklySalesReportDto
    {
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSales { get; set; }
        public float TotalRevenue { get; set; }
    }
}