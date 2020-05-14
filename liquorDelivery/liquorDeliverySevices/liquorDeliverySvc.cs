using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
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

        public int getUserOtpAuthSvc(userOtpAuthRequest userOtpAuthRequest)
        {
            return _liquorDeliveryRepo.getUserOtpAuthsRepo(userOtpAuthRequest);
        }

        public int getUserOtpSvc(mobileNumber MobileNumber)
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
                return 0;
            }
        }

        private string otpSendOtp(int randomNumber, long phoneNumber)
        {
            String WFLocation = ("http://120.138.10.196/API/pushsms.aspx?loginID=ftauto&password=ftauto&mobile="+ phoneNumber + "&text=" + randomNumber +"&senderid=SEDIND&route_id=4&Unicode=0");


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(WFLocation);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            String Status_Code = resp.StatusDescription;
            sr.Close();

            return Status_Code;
        }
    }
}
