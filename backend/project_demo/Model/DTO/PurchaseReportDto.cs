namespace project_demo.Model.DTO
{
    public class PurchaseReportDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string type { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public float amount { get; set; }
    }
}
