using Domain.Interfaces.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace liquorDeliverySevices
{
    public class routingSvc : IroutingInterface
    {
        private readonly IliquorDeliverySvcInterface _liquorDeliverySvc;
        public routingSvc(IliquorDeliverySvcInterface liquorDeliverySvc)
        {
            _liquorDeliverySvc = liquorDeliverySvc;
        }
    }
}
