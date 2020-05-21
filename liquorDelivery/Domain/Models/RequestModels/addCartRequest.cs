using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.RequestModels
{
    public class addCartRequest
    {
        public long mobileNo { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public string AddORDelete { get; set; }
        public string sessionToken { get; set; }
    }
}
