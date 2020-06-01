using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.DomainModels
{
    public class quantityDetails
    {
        public string Id { get; set; }
        public string PriceId { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Incart { get; set; }
        public string CartQty { get; set; }
    }
}
