namespace project_demo.Model
{
    public class Transaction
    {
        public int transaction_id {  get; set; }
        public int USerid { get; set; }
        public  string Customername { get; set; }
        public string type { get; set; }
        public int productId { get; set; }
        public float amount { get; set; }
        public int present_stock { get; set; }

    }
}
