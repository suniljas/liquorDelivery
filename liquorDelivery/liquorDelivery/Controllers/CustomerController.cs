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
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/customerprofile")]
        public object customerProfileInsert(customerProfileRequest customerProfileRequest)
        {
            string requestType = "customerProfileRequest";
            var obj = _routingService.routeAndFetchRepository(customerProfileRequest, requestType);
            return obj;

        }
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/customerprofileload")]
        public object CustomerProfileLoad(customerProfileLoadRequest customerProfileLoadRequest)
        {
            string requestType = "customerProfileLoadRequest";
            var obj = _routingService.routeAndFetchRepository(customerProfileLoadRequest, requestType);
            return obj;

        }
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/notficationupdate")]
        public object updateNotification(notificationUpdateRequest notificationUpdateRequestcs)
        {
            string requestType = "notificationUpdateRequestcs";
            var obj = _routingService.routeAndFetchRepository(notificationUpdateRequestcs, requestType);
            return obj;

        }
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/booking")]
        public object customerBooking(bookingRequest bookingRequest)
        {
            string requestType = "bookingRequest";
            var obj = _routingService.routeAndFetchRepository(bookingRequest, requestType);
            return obj;

        }

    }
}