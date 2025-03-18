namespace project_demo.Model.DTO
{
    public class SalesHistoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime SaleDate { get; set; }
    }
}