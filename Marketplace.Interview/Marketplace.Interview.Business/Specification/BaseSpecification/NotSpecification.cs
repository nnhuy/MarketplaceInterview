
namespace Marketplace.Interview.Business.Specification.BaseSpecification
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        protected readonly ISpecification<T> Specification;

        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !Specification.IsSatisfiedBy(candidate);
        }
    }
}
