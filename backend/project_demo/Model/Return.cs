namespace project_demo.Model
{
    public class Return
    {
        public int ReturnId { get; set; }
        public int OrderId { get; set; }
        public string Reason { get; set; }
        public DateTime RequestDate { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; }
    }
}