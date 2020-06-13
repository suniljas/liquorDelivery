using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.RequestModels
{
    public class customerProfileRequest
    {

        public long mobileNo { get; set; }
        public long shipmobile { get; set; }
        public string nickname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string addline1 { get; set; }
        public string addline2 { get; set; }
        public string city { get; set; }
        public string sessionToken { get; set; }
        public long pincode { get; set; }
        public string addtype { get; set; }
        public string addorupddate { get; set; }
        public int iSDefault { get; set; }
        public string landmark { get; set; }

    }
}
