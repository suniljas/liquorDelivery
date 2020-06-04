using Domain.Models.DomainModels;
using Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ServicesInterfaces
{
    public interface ImapperInterface
    {
        public List<childMenuCategory> MapChildAndQuantity(List<childList> childLisItem, List<quantityDetails> Qty);
    }
}
