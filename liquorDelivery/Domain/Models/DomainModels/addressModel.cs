using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.DomainModels
{
    public class addressModel
    {
        public long Id { get; set; }
        public string Addline1 { get; set; }
        public string Addline2 { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public long Pincode { get; set; }
        public string NickName { get; set; }
        public string AddType { get; set; }
        public int iSDefault { get; set; }
        public long ShippingContact { get; set; }
        public string ShiplastName { get; set; }
        public string ShipFirstName { get; set; }
    }
}
