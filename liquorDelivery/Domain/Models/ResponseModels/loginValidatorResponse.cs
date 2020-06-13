
using Domain.Models.DomainModels;
using System.Collections.Generic;

namespace Domain.Models.ResponseModels
{
    public class loginValidatorResponse
    {
        public string Result { get; set; }
        public profileModel ProfileDetail { get; set; }
        public List<addressModel> AddressDetails { get; set; }
    }
}

