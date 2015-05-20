using Marketplace.Interview.Business.Basket;
using Marketplace.Interview.Business.Shipping;
using Marketplace.Interview.Business.Specification;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Interview.Tests
{
    [TestFixture]
   public class TobeDuplicateSpecificationTest
    {

        [Test]
        public void IsSatisfiedByTest()
        {
            var perRegionAnotherShippingOption = new PerRegionAnotherShipping()
            {
                PerRegionCosts = new[]
                                                                       {
                                                                           new RegionShippingCost()
                                                                               {
                                                                                   DestinationRegion =
                                                                                       RegionShippingCost.Regions.UK,
                                                                                   Amount = .75m
                                                                               },
                                                                           new RegionShippingCost()
                                                                               {
                                                                                   DestinationRegion =
                                                                                       RegionShippingCost.Regions.Europe,
                                                                                   Amount = 1.5m
                                                                               }
                                                                       },
            };
            var basket = new Basket()
            {
                LineItems = new List<LineItem>
                                                 {
                                                      new LineItem()
                                                         {
                                                             DeliveryRegion = RegionShippingCost.Regions.UK,
                                                             Shipping = perRegionAnotherShippingOption
                                                         },
                                                          new LineItem()
                                                         {
                                                             DeliveryRegion = RegionShippingCost.Regions.UK,
                                                             Shipping = perRegionAnotherShippingOption
                                                         }
                                                 }
            };
            var tobeDuplicateSpecification = new ToBeDupliCateSpecification();
            Assert.IsTrue(tobeDuplicateSpecification.IsSatisfiedBy(basket));
        }
    }
}
