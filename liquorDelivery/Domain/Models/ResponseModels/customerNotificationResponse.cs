using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ResponseModels
{
    public class customerNotificationResponse
    {
        public List<notificationList> Notifications { get; set; }
        public string ResponseCode { get; set; }
    }
}
