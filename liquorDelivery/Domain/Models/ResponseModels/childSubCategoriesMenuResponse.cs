using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class childSubCategoriesMenuResponse
    {
        public string ResponseCode { get; set; }
        public List<childCategory> SubCategory { get; set; }
    }
}
