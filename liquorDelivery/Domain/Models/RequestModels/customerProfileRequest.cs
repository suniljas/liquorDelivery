using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.RequestModels
{
    public class customerProfileRequest
    {

        public long mobileNo { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string addline1 { get; set; }
        public string addline2 { get; set; }
        public string city { get; set; }
        public string sessionToken { get; set; }
        public string state { get; set; }
        public long pincode { get; set; }
        public string addtype { get; set; }
        public string AddorUpdate { get; set; }

    }
}
