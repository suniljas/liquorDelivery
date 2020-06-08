using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.DomainModels
{
    public class addressModel
    {
        public string Addline1 { get; set; }
        public string Addline2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Pincode { get; set; }
    }
}
