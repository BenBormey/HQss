using System;

namespace unt_bingoo.Class
{
    public class CustomerItem
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
