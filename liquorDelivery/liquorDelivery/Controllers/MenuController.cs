using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace liquorDelivery.Controllers
{
    [Route("V1/liquor")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IroutingInterface _routingService;
        public MenuController(IroutingInterface routingService)
        {
            _routingService = routingService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/parentMenu")]
        public object parentMenuReq(parentsCategoriesMenuRequest parentsCategoriesMenuRequest)
        {
            string requestType = "parentsCategoriesMenuRequest";
            var obj = _routingService.routeAndFetchRepository(parentsCategoriesMenuRequest, requestType);
            return obj;

        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        [Route("user/childMenu")]
        public object childMenuReq(childSubCategoriesMenuRequest childSubCategoriesMenuRequest)
        {
            string requestType = "childSubCategoriesMenuRequest";
            var obj = _routingService.routeAndFetchRepository(childSubCategoriesMenuRequest, requestType);
            return obj;

        }
    }
}