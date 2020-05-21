using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;

namespace liquorDeliverySevices
{
    public class routingSvc : IroutingInterface
    {
        private readonly IliquorDeliverySvcInterface _liquorDeliverySvc;
        public routingSvc(IliquorDeliverySvcInterface liquorDeliverySvc)
        {
            _liquorDeliverySvc = liquorDeliverySvc;
        }

        public object routeAndFetchRepository(object apiRequest, string requestType)
        {
            object serviceResponse = null;

            if (requestType == "userOtpAuth")
            {
                userOtpAuthRequest UserOtpAuthRequest = new userOtpAuthRequest();
                UserOtpAuthRequest = apiRequest as userOtpAuthRequest;
                return serviceResponse = _liquorDeliverySvc.getUserOtpAuthSvc(UserOtpAuthRequest);
            }
            else if ( requestType == "userOtpReq")
            {
                mobileNumber MobileNumber = new mobileNumber();
                MobileNumber = apiRequest as mobileNumber;
                return serviceResponse = _liquorDeliverySvc.getUserOtpSvc(MobileNumber);
            }
            else if (requestType == "parentsCategoriesMenuRequest")
            {
                parentsCategoriesMenuRequest parentsCategoriesMenuRequest = new parentsCategoriesMenuRequest();
                parentsCategoriesMenuRequest = apiRequest as parentsCategoriesMenuRequest;
                return serviceResponse = _liquorDeliverySvc.getParentCategoriesMenuSvc(parentsCategoriesMenuRequest);
            }
            else if (requestType == "childSubCategoriesMenuRequest")
            {
                childSubCategoriesMenuRequest childSubCategoriesMenuRequest = new childSubCategoriesMenuRequest();
                childSubCategoriesMenuRequest = apiRequest as childSubCategoriesMenuRequest;
                return serviceResponse = _liquorDeliverySvc.getChildCategoriesMenuSvc(childSubCategoriesMenuRequest);
            }
            else if (requestType == "addCartRequest")
            {
                addCartRequest addCartRequest = new addCartRequest();
                addCartRequest = apiRequest as addCartRequest;
                return serviceResponse = _liquorDeliverySvc.getAddCartSvc(addCartRequest);
            }
            else if (requestType == "loadCartRequest")
            {
                loadCartRequest loadCartRequest = new loadCartRequest();
                loadCartRequest = apiRequest as loadCartRequest;
                return serviceResponse = _liquorDeliverySvc.getLoadCartSvc(loadCartRequest);
            }


            return serviceResponse;
        }
    }
}
