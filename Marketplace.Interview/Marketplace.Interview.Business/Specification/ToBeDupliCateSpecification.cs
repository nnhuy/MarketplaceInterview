using Marketplace.Interview.Business.Basket;
using Marketplace.Interview.Business.Shipping;
using Marketplace.Interview.Business.Specification.BaseSpecification;
using System.Linq;
namespace Marketplace.Interview.Business.Specification
{
    public class ToBeDupliCateSpecification : CompositeSpecification<Basket.Basket>
    {
        public override bool IsSatisfiedBy(Basket.Basket basket)
        {
            return basket.LineItems.Where(t => t.Shipping.GetType() == (typeof(PerRegionAnotherShipping))).GroupBy(x => new { x.SupplierId, x.DeliveryRegion }).Any(g => g.Count() > 1);
        }
    }
}
