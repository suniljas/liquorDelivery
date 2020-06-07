
using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace liquorDelivery.Controllers
{
    [Route("V1/liquor")]
    [ApiController]
    public class CheckoutController : Controller
    {
        private readonly IroutingInterface _routingService;
        public CheckoutController(IroutingInterface routingService)
        {
            _routingService = routingService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/addCart")]
        public object addCartReq(addCartRequest addCartRequest)
        {
            string requestType = "addCartRequest";
            var obj = _routingService.routeAndFetchRepository(addCartRequest, requestType);
            return obj;

        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/loadCart")]
        public object addCartReq(loadCartRequest loadCartRequest)
        {
            string requestType = "loadCartRequest";
            var obj = _routingService.routeAndFetchRepository(loadCartRequest, requestType);
            return obj;

        }

    }
}