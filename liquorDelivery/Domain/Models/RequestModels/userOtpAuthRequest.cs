using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models.RequestModels
{
    public class userOtpAuthRequest
    {
        public long mobileNumber { get; set; }
        public string fcmid { get; set; }
        public string devicemodel { get; set; }
        public string osversion { get; set; }
        public string deviceid_1 { get; set; }
        public string deviceid_2 { get; set; }
        public int otp { get; set; }
        [JsonIgnore]
        public string output_param { get; set; }
    }
}
