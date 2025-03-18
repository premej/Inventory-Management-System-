using System;

namespace project_demo.Model.DTO
{
    public class ReturnRequestDto
    {
        public int ReturnId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected"
        public DateTime RequestDate { get; set; }
    }
}