using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class loadCartResponse
    {
        public string ResponseCode { get; set; }
        public string CartCount { get; set; }
        public string DeliveryCharge { get; set; }
        public string ExtraCharge { get; set; }
        public string TaxPer { get; set; }
        public List<CartInfo> CartDetails { get; set; }
    }
}
