using Dapper;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public loginValidatorResponse getUserOtpAuthRepo(userOtpAuthRequest userOtpAuthRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var authResult = connection.QuerySingleOrDefault<userOtpAuthResponse>("[dbo].use_sp_logincall_validate",
                    new
                    {
                        userOtpAuthRequest.mobileNo,
                        userOtpAuthRequest.fcmid,
                        userOtpAuthRequest.devicemodel,
                        userOtpAuthRequest.deviceid_1,
                        userOtpAuthRequest.deviceid_2,
                        userOtpAuthRequest.otp,
                        userOtpAuthRequest.osversion
                    },
                commandType: CommandType.StoredProcedure);

                if(((authResult.Result == "0") || (authResult.Result == "8")))
                {
                    var loginvalidatorresponse = new loginValidatorResponse
                    {
                        ResponseCode = authResult.Result,
                        SessionToken = null
                    };

                    return loginvalidatorresponse;
                }
                else
                {
                    var loginvalidatorresponse = new loginValidatorResponse
                    {
                        ResponseCode = "1",
                        SessionToken = authResult.Result
                    };

                    return loginvalidatorresponse;
                }
            }
        }

        public parentCategoriesMenuResponse getParentMenuRepo(parentsCategoriesMenuRequest parentsCategoriesMenuRequest)
        {

            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parentCategoriesMenu = connection.QueryMultiple("[dbo].use_sp_get_category",
                    new
                    {
                        parentsCategoriesMenuRequest.mobileNo,
                        parentsCategoriesMenuRequest.sessionToken
                    },
                commandType: CommandType.StoredProcedure);

                var result = parentCategoriesMenu.ReadSingleOrDefault<resultmodel> ();

                if(result.Result == "1")
                {
                    var cartcnt = parentCategoriesMenu.Read<cartDetails>();
                    var parentCat = parentCategoriesMenu.Read<parentCategory>().ToList();

                    var cartcount = cartcnt.ToArray();

                    var finResult = new parentCategoriesMenuResponse()
                    {
                        CartCount = cartcount[0].CartCount.ToString(),
                        Category = parentCat.ToList(),
                        ResponseCode = "1"
                    };

                    return finResult;
                }
                else
                {
                    return new parentCategoriesMenuResponse()
                    {
                        CartCount = null,
                        Category = null,
                        ResponseCode = "0"
                    };
                }

            }
        }

        public userOtpResponse getUserOtpRepo(mobileNumber MobileNumber, int otp)
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

                if (authResult.Result == "0")
                {
                    var userotprsesponse = new userOtpResponse
                    {
                        ResponseCode = authResult.Result,
                        Message = "OTP Failed to Sent"
                    };

                    return userotprsesponse;
                }
                else if((authResult.Result == "8"))
                {
                    var userotprsesponse = new userOtpResponse
                    {
                        ResponseCode = authResult.Result,
                        Message = "DB Error"
                    };

                    return userotprsesponse;
                }
                else
                {
                    var userotprsesponse = new userOtpResponse
                    {
                        ResponseCode = authResult.Result,
                        Message = "OTP Successfully Sent"
                    };

                    return userotprsesponse;
                }
            }
        }
    }
}
