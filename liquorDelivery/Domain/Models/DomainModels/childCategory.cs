using Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.DomainModels
{
    public class childCategory
    {
        public List<childMenuCategory> SubCategoryList { get; set; }
        public List<quantityDetails> Qty { get; set; }
    }
}
