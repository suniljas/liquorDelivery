using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.RepositoryInterfaces
{
   public interface IliquorDeliveryRepoInterface
    {
        int getUserOtpAuthsRepo(userOtpAuthRequest userOtpAuthRequest);
        int getUserOtpRepo(mobileNumber MobileNumber,int otp);
    }
}
