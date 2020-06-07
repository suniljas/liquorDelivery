using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class customerProfileLoadResponse
    {
        public string ResponseCode { get; set; }
        public profileModel profile { get; set; }
        public List<addressModel> address { get; set; }
    }
}
