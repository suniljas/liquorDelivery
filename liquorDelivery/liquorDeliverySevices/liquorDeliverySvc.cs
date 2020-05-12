using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServicesInterfaces;
using System;

namespace liquorDeliverySevices
{
    public class liquorDeliverySvc : IliquorDeliverySvcInterface
    {
        private readonly IliquorDeliveryRepoInterface _liquorDeliveryRepo;

        public liquorDeliverySvc (IliquorDeliveryRepoInterface liquorDeliveryRepo)
        {
            _liquorDeliveryRepo = liquorDeliveryRepo;
        }
    }
}
