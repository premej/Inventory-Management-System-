using System;

namespace project_demo.Model.DTO
{
    public class UserTransactionDto
    {
        public string ProductName { get; set; }
        public string Type { get; set; } // "In" for purchase, "Out" for sale
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int present_stock { get; set; }
    }
}
