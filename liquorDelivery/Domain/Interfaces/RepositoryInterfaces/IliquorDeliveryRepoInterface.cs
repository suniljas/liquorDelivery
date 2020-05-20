using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.RepositoryInterfaces
{
   public interface IliquorDeliveryRepoInterface
    {
        loginValidatorResponse getUserOtpAuthRepo(userOtpAuthRequest userOtpAuthRequest);
        parentCategoriesMenuResponse getParentMenuRepo(parentsCategoriesMenuRequest parentsCategoriesMenuRequest);
        userOtpResponse getUserOtpRepo(mobileNumber MobileNumber,int otp);
    }
}
