using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using System;
using System.IO;
using System.Net;

namespace liquorDeliverySevices
{
    public class liquorDeliverySvc : IliquorDeliverySvcInterface
    {
        private readonly IliquorDeliveryRepoInterface _liquorDeliveryRepo;

        public liquorDeliverySvc (IliquorDeliveryRepoInterface liquorDeliveryRepo)
        {
            _liquorDeliveryRepo = liquorDeliveryRepo;
        }

        public parentCategoriesMenuResponse getParentCategoriesMenuSvc(parentsCategoriesMenuRequest parentsCategoriesMenuRequest)
        {
            var result = _liquorDeliveryRepo.getParentMenuRepo(parentsCategoriesMenuRequest);
            return result as parentCategoriesMenuResponse;
        }

        public childSubCategoriesMenuResponse getChildCategoriesMenuSvc(childSubCategoriesMenuRequest childSubCategoriesMenuRequest)
        {
            var result = _liquorDeliveryRepo.getChildMenuRepo(childSubCategoriesMenuRequest);
            return result as childSubCategoriesMenuResponse;
        }

        public loginValidatorResponse getUserOtpAuthSvc(userOtpAuthRequest userOtpAuthRequest)
        {
           var result = _liquorDeliveryRepo.getUserOtpAuthRepo(userOtpAuthRequest);
           return result as loginValidatorResponse;
        }

        public userOtpResponse getUserOtpSvc(mobileNumber MobileNumber)
        {
            int randomNumber;
            Random otpRandom = new Random();
            randomNumber = (otpRandom.Next(1000, 9999));

            long phoneNumber = MobileNumber.mobileNo;
            string resuktTxt = otpSendOtp(randomNumber, phoneNumber);

            if(resuktTxt == "OK")
            {
                return _liquorDeliveryRepo.getUserOtpRepo(MobileNumber, randomNumber);
            }
            else
            {
                var userotprsesponse = new userOtpResponse
                {
                    ResponseCode = "9",
                    Message = "SMS gateway failiure"
                };

                return userotprsesponse;
            }
        }

        private string otpSendOtp(int randomNumber, long phoneNumber)
        {
            String WFLocation = ("http://hpapi.dial4sms.com/SendSMS/sendmsg.php?uname=ftauto&pass=Ftauto@1&send=sedind&dest=" + phoneNumber + "&msg=" + randomNumber + " is the OTP for login , do not share this with anyone.");


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(WFLocation);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            String Status_Code = resp.StatusDescription;
            sr.Close();

            return Status_Code;
        }

        public addCartResponse getAddCartSvc(addCartRequest addCartRequest)
        {
            var result = _liquorDeliveryRepo.getAddCartRepo(addCartRequest);
            return result as addCartResponse;
        }

        public loadCartResponse getLoadCartSvc(loadCartRequest loadCartRequest)
        {
            var result = _liquorDeliveryRepo.getLoadCartRepo(loadCartRequest);
            return result as loadCartResponse;
        }

        public customerNotificationResponse getCustNotificationSvc(notificationRequest notificationRequest)
        {
            var result = _liquorDeliveryRepo.getCustomerNotificationRepo(notificationRequest);
            return result as customerNotificationResponse;
        }

        public responseCodeResponse getCustomerProfileInsertSvc(customerProfileRequest customerProfileRequest)
        {
            throw new NotImplementedException();
        }

        public customerProfileLoadResponse getCustomerProfileLoadSvc(customerProfileLoadRequest customerProfileLoadRequest)
        {
            throw new NotImplementedException();
        }

        public responseCodeResponse getUpdateNotificationSvc(notificationUpdateRequest notificationUpdateRequest)
        {
            throw new NotImplementedException();
        }

        public responseCodeResponse getCustomerBookingSvc(bookingRequest bookingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
