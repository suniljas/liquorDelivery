using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class childSubCategoriesMenuResponse
    {
        public string ResponseCode { get; set; }
        public string cartCount { get; set; }        
        public List<childMenuCategory> SubCategoryList { get; set; }

    }
}
