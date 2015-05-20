using Marketplace.Interview.Business.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Interview.Business.Shipping
{
   public class PerRegionAnotherShipping : PerRegionShipping
    {
       public override string GetDescription(LineItem lineItem, Basket.Basket basket)
       {
           return string.Format("Shipping to {0} (*)", lineItem.DeliveryRegion);
       }
    }
}
