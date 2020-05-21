using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ServicesInterfaces
{
    public interface IliquorDeliverySvcInterface
    {
        loginValidatorResponse getUserOtpAuthSvc(userOtpAuthRequest userOtpAuthRequest);
        userOtpResponse getUserOtpSvc(mobileNumber MobileNumber);
        parentCategoriesMenuResponse getParentCategoriesMenuSvc(parentsCategoriesMenuRequest parentsCategoriesMenuRequest);
        childSubCategoriesMenuResponse getChildCategoriesMenuSvc(childSubCategoriesMenuRequest childSubCategoriesMenuRequest);
        addCartResponse getAddCartSvc(addCartRequest addCartRequest);
        loadCartResponse getLoadCartSvc(loadCartRequest loadCartRequest);

    }
}
