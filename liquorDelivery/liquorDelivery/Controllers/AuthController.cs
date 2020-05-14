using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace liquorDelivery.Controllers
{
    [Route("V1/liquor")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IroutingInterface _routingService;
        public AuthController(IroutingInterface routingService)
        {
            _routingService = routingService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/auth")]
        public object userOtpAuth(userOtpAuthRequest userOtpAuthRequest)
        {
            string requestType = "userOtpAuth";
            var obj = _routingService.routeAndFetchRepository(userOtpAuthRequest,requestType);
            return obj;

        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/otpreq")]
        public object userOtpReq(mobileNumber mobileNumber)
        {
            string requestType = "userOtpReq";
            var obj = _routingService.routeAndFetchRepository(mobileNumber, requestType);
            return obj;

        }
    }
}