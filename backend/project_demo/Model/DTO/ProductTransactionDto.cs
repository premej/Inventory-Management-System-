namespace project_demo.Model.DTO
{
    public class ProductTransactionDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
    }
}
