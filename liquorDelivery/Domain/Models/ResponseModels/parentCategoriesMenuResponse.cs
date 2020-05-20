using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class parentCategoriesMenuResponse
    {
        public string ResponseCode { get; set; }
        public string CartCount { get; set; }
        public List<parentCategory> Category { get; set; }
    }
}
