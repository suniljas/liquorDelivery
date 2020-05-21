using Domain.Models.DomainModels;
using System.Collections.Generic;

namespace Domain.Models.ResponseModels
{
    public class addCartResponse
    {
        public string ResponseCode { get; set; }
        public List<CartInfo> CartDetails { get; set; }
    }
}
