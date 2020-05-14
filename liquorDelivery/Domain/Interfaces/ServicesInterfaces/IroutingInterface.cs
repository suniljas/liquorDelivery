using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ServicesInterfaces
{
    public interface IroutingInterface
    {
        object routeAndFetchRepository(object apiRequest, string requestType);
    }
}
