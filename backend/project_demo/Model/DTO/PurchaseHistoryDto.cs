namespace project_demo.Model.DTO
{
    public class PurchaseHistoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
        public float amount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}