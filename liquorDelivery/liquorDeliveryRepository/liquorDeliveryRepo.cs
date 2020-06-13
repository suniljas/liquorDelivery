using Dapper;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Domain.Models.ResponseModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace liquorDeliveryRepository
{
    public class liquorDeliveryRepo : IliquorDeliveryRepoInterface
    {
        private readonly IConfiguration _configuration;
        private readonly ImapperInterface _mapper;
        public liquorDeliveryRepo(IConfiguration configuration, ImapperInterface mapper)
        {
            _configuration = configuration;
            _mapper = mapper;

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

                if (((authResult.Result == "0") || (authResult.Result == "8")))
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

                var result = parentCategoriesMenu.ReadSingleOrDefault<resultmodel>();

                if (result.Result == "1")
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

        public childSubCategoriesMenuResponse getChildMenuRepo(childSubCategoriesMenuRequest childSubCategoriesMenuRequest)
        {

            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var subCategoriesMenu = connection.QueryMultiple("[dbo].use_sp_get_subcategory",
                    new
                    {
                        childSubCategoriesMenuRequest.mobileNo,
                        childSubCategoriesMenuRequest.sessionToken,
                        childSubCategoriesMenuRequest.categoryid
                    },
                commandType: CommandType.StoredProcedure);

                var result = subCategoriesMenu.ReadSingleOrDefault<resultmodel>();

                if (result.Result == "1")
                {
                    var cartCount = subCategoriesMenu.ReadSingle<cartCountValue>();
                    var childCat = subCategoriesMenu.Read<childList>().ToList();
                    var qty = subCategoriesMenu.Read<quantityDetails>().ToList();


                    List<childMenuCategory> mapperListResponse = _mapper.MapChildAndQuantity(childCat.ToList(), qty.ToList());


                    var finResult = new childSubCategoriesMenuResponse()
                    {
                        SubCategoryList = mapperListResponse,
                        ResponseCode = "1",
                        cartCount = cartCount.CartCount
                    };


                    return finResult;
                }
                else
                {
                    return new childSubCategoriesMenuResponse()
                    {
                        SubCategoryList = null,
                        ResponseCode = "0",
                        cartCount = null
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
                else if ((authResult.Result == "8"))
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

        public addCartResponse getAddCartRepo(addCartRequest addCartRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var addcart = connection.QueryMultiple("[dbo].use_sp_add_cart",
                    new
                    {
                        addCartRequest.mobileNo,
                        addCartRequest.sessionToken,
                        addCartRequest.AddORDelete,
                        addCartRequest.Id,
                        addCartRequest.Price,
                        addCartRequest.ProductName,
                        addCartRequest.Qty,
                        addCartRequest.CartQty
                    },
                commandType: CommandType.StoredProcedure);

                var result = addcart.ReadSingleOrDefault<resultmodel>();

                if (result.Result == "1")
                {
                    var cartCount = addcart.ReadSingle<cartCountValue>();
                    var addCartInfo = addcart.Read<CartInfo>().ToList();

                    var finResult = new addCartResponse()
                    {
                        CartDetails = addCartInfo.ToList(),
                        ResponseCode = "1",
                        CartCount = cartCount.CartCount
                    };

                    return finResult;
                }
                else
                {
                    return new addCartResponse()
                    {
                        CartDetails = null,
                        ResponseCode = "0",
                        CartCount = null
                    };
                }

            }
        }

        public loadCartResponse getLoadCartRepo(loadCartRequest loadCartRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var loadCart = connection.QueryMultiple("[dbo].use_sp_load_cart",
                    new
                    {
                        loadCartRequest.mobileNo,
                        loadCartRequest.sessionToken
                    },
                commandType: CommandType.StoredProcedure);

                var result = loadCart.ReadSingleOrDefault<resultmodel>();

                if (result != null)
                {

                    if (result.Result == "1")
                    {
                        var cartCount = loadCart.ReadSingle<cartCountValue>();
                        var loadCartInfo = loadCart.Read<CartInfo>().ToList();
                        var otherCharges = loadCart.Read<otherCharges>();


                        var otherChargesArray = otherCharges.ToArray();


                        var finResult = new loadCartResponse()
                        {
                            CartDetails = loadCartInfo.ToList(),
                            ResponseCode = "1",
                            CartCount = cartCount.CartCount,
                            DeliveryCharge = otherChargesArray[0].DeliveryCharge,
                            TaxPer = otherChargesArray[0].TaxPer,
                            ExtraCharge = otherChargesArray[0].ExtraCharge

                        };

                        return finResult;
                    }
                    else if (result.Result == "0")
                    {
                        return new loadCartResponse()
                        {
                            CartDetails = null,
                            ResponseCode = "0",
                            CartCount = null,
                            DeliveryCharge = null,
                            TaxPer = null,
                            ExtraCharge = null
                        };
                    }
                    else if (result.Result == "2")
                    {
                        return new loadCartResponse()
                        {
                            CartDetails = null,
                            ResponseCode = "2",
                            CartCount = null,
                            DeliveryCharge = null,
                            TaxPer = null,
                            ExtraCharge = null
                        };
                    }
                    else if (result.Result == "8")
                    {
                        return new loadCartResponse()
                        {
                            CartDetails = null,
                            ResponseCode = "8",
                            CartCount = null,
                            DeliveryCharge = null,
                            TaxPer = null,
                            ExtraCharge = null
                        };
                    }
                    else
                    {
                        return new loadCartResponse()
                        {
                            CartDetails = null,
                            ResponseCode = "0",
                            CartCount = null,
                            DeliveryCharge = null,
                            TaxPer = null,
                            ExtraCharge = null
                        };
                    }
                }
                else
                {
                    return new loadCartResponse()
                    {
                        CartDetails = null,
                        ResponseCode = "0",
                        CartCount = null,
                        DeliveryCharge = null,
                        TaxPer = null,
                        ExtraCharge = null
                    };
                }

            }
        }

        public customerNotificationResponse getCustomerNotificationRepo(notificationRequest notificationRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var customerNotification = connection.QueryMultiple("[dbo].use_sp_cust_notifications",
                    new
                    {
                        notificationRequest.mobileNo,
                        notificationRequest.sessionToken
                    },
                commandType: CommandType.StoredProcedure);

                var result = customerNotification.ReadSingleOrDefault<resultmodel>();

                if (result != null)
                {
                    if (result.Result == "1")
                    {
                        var notification = customerNotification.Read<notificationList>();

                        var finResult = new customerNotificationResponse()
                        {
                            Notifications = notification.ToList(),
                            ResponseCode = "1"
                        };

                        return finResult;
                    }
                    else if (result.Result == "8")
                    {
                        return new customerNotificationResponse()
                        {
                            Notifications = null,
                            ResponseCode = "8"
                        };
                    }
                    else if (result.Result == "0")
                    {
                        return new customerNotificationResponse()
                        {
                            Notifications = null,
                            ResponseCode = "0"
                        };
                    }
                    else
                    {
                        return new customerNotificationResponse()
                        {
                            Notifications = null,
                            ResponseCode = "0"
                        };
                    }
                }
                else
                {
                    return new customerNotificationResponse()
                    {
                        Notifications = null,
                        ResponseCode = "0"
                    };
                }

            }
        }

        public customerProfileResponse getCustomerProfileInsertRepo(customerProfileRequest customerProfileRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var resultResp = connection.QueryMultiple("[dbo].use_sp_cust_profile",
                    new
                    {
                        customerProfileRequest.mobileNo,
                        customerProfileRequest.shipmobile,
                        customerProfileRequest.firstname,
                        customerProfileRequest.lastname,
                        customerProfileRequest.iSDefault,
                        customerProfileRequest.landmark,
                        customerProfileRequest.addline1,
                        customerProfileRequest.addline2,
                        customerProfileRequest.addorupddate,
                        customerProfileRequest.addtype,
                        customerProfileRequest.city,
                        customerProfileRequest.email,
                        customerProfileRequest.pincode,
                        customerProfileRequest.sessionToken,
                        customerProfileRequest.nickname
                    },
                commandType: CommandType.StoredProcedure);

                var result = resultResp.ReadSingleOrDefault<resultmodel>();
                
                if (result != null)
                {

                    if (result.Result == "1")
                    {
                        var addressId = resultResp.ReadSingle<string>();

                        return new customerProfileResponse()
                        {
                            ResponseCode = "1",
                            AddressId = addressId.ToString()
                        };
                    }
                    else if (result.Result == "0")
                    {
                        return new customerProfileResponse()
                        {
                            ResponseCode = "0",
                            AddressId = null
                        };
                    }
                    else if (result.Result == "2")
                    {
                        return new customerProfileResponse()
                        {
                            ResponseCode = "0",
                            AddressId = null
                        };
                    }
                    else if (result.Result == "8")
                    {
                        return new customerProfileResponse()
                        {
                            ResponseCode = "8",
                            AddressId = null
                        };
                    }
                    else
                    {
                        return new customerProfileResponse()
                        {
                            ResponseCode = "0",
                            AddressId = null
                        };
                    }
                }
                else
                {
                    return new customerProfileResponse()
                    {
                        ResponseCode = "0",
                        AddressId = null
                    };
                }

            }
        }

        public customerProfileLoadResponse getCustomerProfileLoadRepo(customerProfileLoadRequest customerProfileLoadRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var customerProfileLoad = connection.QueryMultiple("[dbo].use_sp_cust_profile_load",
                    new
                    {
                        customerProfileLoadRequest.mobileNo,
                        customerProfileLoadRequest.sessionToken
                    },
                commandType: CommandType.StoredProcedure);

                var result = customerProfileLoad.ReadSingleOrDefault<resultmodel>();

                if (result.Result == "1")
                {
                    var profileModel = customerProfileLoad.Read<profileModel>();
                    var addresses = customerProfileLoad.Read<addressModel>().ToList();

                    var profileArray = profileModel.ToArray();

                    var finResult = new customerProfileLoadResponse()
                    {
                        ResponseCode = "1",
                        profile = profileArray[0],
                        address = addresses.ToList()

                    };

                    return finResult;
                }
                else
                {
                    return new customerProfileLoadResponse()
                    {
                        ResponseCode = "0",
                        profile = null,
                        address = null
                    };
                }

            }
        }

        public responseCodeResponse getUpdateNotificationRepo(notificationUpdateRequest notificationUpdateRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault("[dbo].use_sp_notification_update",
                    new
                    {
                        notificationUpdateRequest.mobileNo,
                        notificationUpdateRequest.readstatus,
                        notificationUpdateRequest.sessionToken
                    },
                commandType: CommandType.StoredProcedure);

                if (result != null)
                {

                    if (result.Result == "1")
                    {

                        return new responseCodeResponse()
                        {
                            ResponseCode = "1"
                        };
                    }
                    else if (result.Result == "0")
                    {
                        return new responseCodeResponse()
                        {
                            ResponseCode = "0"
                        };
                    }
                    else if (result.Result == "2")
                    {
                        return new responseCodeResponse()
                        {
                            ResponseCode = "0"
                        };
                    }
                    else if (result.Result == "8")
                    {
                        return new responseCodeResponse()
                        {
                            ResponseCode = "8"
                        };
                    }
                    else
                    {
                        return new responseCodeResponse()
                        {
                            ResponseCode = "0"
                        };
                    }
                }
                else
                {
                    return new responseCodeResponse()
                    {
                        ResponseCode = "0"
                    };
                }

            }
        }

        public customerBookingResponse getCustomerBookingRepo(bookingRequest bookingRequest)
        {
            string connectionString = getConnectionName("localDBConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var bookingResult = connection.QueryMultiple("[dbo].use_sp_booking",
                    new
                    {
                        bookingRequest.mobileNo,
                        bookingRequest.sessionToken,
                        bookingRequest.checkout
                    },
                commandType: CommandType.StoredProcedure);

                var result = bookingResult.ReadSingleOrDefault<resultmodel>();

                if (result != null)
                {

                    if (result.Result == "1")
                    {
                        var bookingID = bookingResult.ReadSingle<bookingID>();

                        return new customerBookingResponse()
                        {
                            ResponseCode = "1",
                            BookingId = bookingID.BookingId
                        };
                    }
                    else if (result.Result == "0")
                    {
                        return new customerBookingResponse()
                        {
                            ResponseCode = "0",
                            BookingId = null
                        };
                    }
                    else if (result.Result == "2")
                    {
                        return new customerBookingResponse()
                        {
                            ResponseCode = "0",
                            BookingId = null
                        };
                    }
                    else if (result.Result == "8")
                    {
                        return new customerBookingResponse()
                        {
                            ResponseCode = "8",
                            BookingId = null
                        };
                    }
                    else
                    {
                        return new customerBookingResponse()
                        {
                            ResponseCode = "0",
                            BookingId = null
                        };
                    }
                }
                else
                {
                    return new customerBookingResponse()
                    {
                        ResponseCode = "0",
                        BookingId = null
                    };
                }

            }
        }
    }
}
