namespace project_demo.Model.DTO
{
    public class SalesReportDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string type { get; set; }
        public int Quantity { get; set; }
        public float amount { get; set; }
        //public float TotalRevenue { get; set; }
    }
}