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
        childSubCategoriesMenuResponse getChildMenuRepo(childSubCategoriesMenuRequest childSubCategoriesMenuRequest);
        userOtpResponse getUserOtpRepo(mobileNumber MobileNumber,int otp);
        addCartResponse getAddCartRepo(addCartRequest addCartRequest);
        loadCartResponse getLoadCartRepo(loadCartRequest loadCartRequest);
        customerNotificationResponse getCustomerNotificationRepo(notificationRequest notificationRequest);
    }
}
