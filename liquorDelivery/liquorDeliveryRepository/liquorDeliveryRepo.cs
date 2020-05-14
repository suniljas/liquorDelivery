using Dapper;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Schema;

namespace liquorDeliveryRepository
{
    public class liquorDeliveryRepo : IliquorDeliveryRepoInterface
    {
        private readonly IConfiguration _configuration;
        public liquorDeliveryRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string getConnectionName(string connName)
        {
            var conn = _configuration.GetSection("ConnectionStrings").GetSection(connName).Value;

            if (connName == "localDBConnection")
            {
                conn = _configuration.GetSection("ConnectionStrings").GetSection(connName).Value;
            }

            return conn;
        }
        public int getUserOtpAuthsRepo(userOtpAuthRequest userOtpAuthRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection( connectionString ))
            {
                connection.Open();
                var authResult = connection.QuerySingleOrDefault<userOtpAuthResponse>("[dbo].use_sp_logincall_validate",
                    new
                    {
                        mobileNo = userOtpAuthRequest.mobileNumber,
                        userOtpAuthRequest.fcmid,
                        userOtpAuthRequest.devicemodel,
                        userOtpAuthRequest.deviceid_1,
                        userOtpAuthRequest.deviceid_2,
                        userOtpAuthRequest.otp,
                        userOtpAuthRequest.osversion
                    },
                commandType: CommandType.StoredProcedure);

                return authResult.Result;
            }
        }

        public int getUserOtpRepo(mobileNumber MobileNumber, int otp)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var authResult = connection.QuerySingleOrDefault<userOtpAuthResponse>("[dbo].use_sp_logincall",
                    new
                    {
                        MobileNumber.mobileNo,
                        otp,
                        reference = ""
                    },
                commandType: CommandType.StoredProcedure);

                return authResult.Result;
            }
        }
    }
}
