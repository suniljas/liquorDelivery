using Domain.Interfaces.ServicesInterfaces;
using Domain.Models.DomainModels;
using Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace liquorDeliverySevices
{
    public class mapperSvc : ImapperInterface
    {
        public List<childMenuCategory> MapChildAndQuantity(List<childList> childLisItem, List<quantityDetails> Qty)
        {
            childMenuCategory childMenuCategory = new childMenuCategory();
            List<childMenuCategory> childMenuCategorylst = new List<childMenuCategory>();

            foreach(var items in childLisItem)
            {
                childMenuCategory.Id = items.Id;
                childMenuCategory.Name = items.Name;
                childMenuCategory.Path = items.Path;
                foreach (var Qtyitems in Qty)
                {
                    if (Qtyitems.Id == items.Id)
                    {
                        childMenuCategory.Qty = Qty;
                        break;
                    }
                }

                childMenuCategorylst.Add(childMenuCategory);
            }

            return childMenuCategorylst;
        }
    }
}
