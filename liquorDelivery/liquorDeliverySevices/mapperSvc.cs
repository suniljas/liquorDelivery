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
            List<childMenuCategory> childMenuCategorylst = new List<childMenuCategory>();

            foreach(var items in childLisItem)
            {
                childMenuCategory childMenuCategory = new childMenuCategory();

                childMenuCategory.Id = items.Id;
                childMenuCategory.Name = items.Name;
                childMenuCategory.Path = items.Path;
                foreach (quantityDetails Qtyitems in Qty)
                {
                    if (Qtyitems.Id == items.Id)
                    {
                        if (childMenuCategory.Qty == null)
                        {
                            childMenuCategory.Qty = new List<quantityDetails>();
                        }

                        childMenuCategory.Qty.Add(Qtyitems);
                    }
                }

                childMenuCategorylst.Add(childMenuCategory);
            }

            return childMenuCategorylst;
        }
    }
}
