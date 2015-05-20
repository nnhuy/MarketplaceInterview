using Marketplace.Interview.Business.Specification;
using System.Linq;

namespace Marketplace.Interview.Business.Basket
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(Basket basket);
    }

    public class ShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShipping(Basket basket)
        {
            const decimal discount = 0.5m;
            ToBeDupliCateSpecification _duplicateSpecification = new ToBeDupliCateSpecification();
            foreach (var lineItem in basket.LineItems)
            {
                lineItem.ShippingAmount = lineItem.Shipping.GetAmount(lineItem, basket);
                lineItem.ShippingDescription = lineItem.Shipping.GetDescription(lineItem, basket);
            }
            basket.Shipping = basket.LineItems.Sum(t=>t.ShippingAmount);
            basket.Discount = (_duplicateSpecification.IsSatisfiedBy(basket)) ? discount : 0;
            basket.TotalShipping = basket.Shipping - basket.Discount;
            return basket.Shipping;
        }
    }
}