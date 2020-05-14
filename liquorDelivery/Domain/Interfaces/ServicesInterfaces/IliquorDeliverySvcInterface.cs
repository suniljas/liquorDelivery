using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ServicesInterfaces
{
    public interface IliquorDeliverySvcInterface
    {
        int getUserOtpAuthSvc(userOtpAuthRequest userOtpAuthRequest);
        int getUserOtpSvc(mobileNumber MobileNumber);
    }
}
