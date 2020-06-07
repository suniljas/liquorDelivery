using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.RequestModels
{
    public class bookingRequest
    {
        public long mobileNo { get; set; }
        public string sessionToken { get; set; }
        public int checkout { get; set; }
    }
}
