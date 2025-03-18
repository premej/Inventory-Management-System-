namespace project_demo.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
    }
}