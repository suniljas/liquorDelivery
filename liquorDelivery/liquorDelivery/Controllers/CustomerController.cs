using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace liquorDelivery.Controllers
{
    [Route("V1/liquor")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IroutingInterface _routingService;
        public CustomerController(IroutingInterface routingService)
        {
            _routingService = routingService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/notification")]
        public object addCartReq(notificationRequest notificationRequest)
        {
            string requestType = "notificationRequest";
            var obj = _routingService.routeAndFetchRepository(notificationRequest, requestType);
            return obj;

        }

    }
}