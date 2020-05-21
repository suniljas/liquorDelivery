using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class loadCartResponse
    {
        public string ResponseCode { get; set; }
        public List<CartInfo> CartDetails { get; set; }
    }
}
