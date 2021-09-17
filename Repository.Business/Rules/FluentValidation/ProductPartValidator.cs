using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.Rules.FluentValidation
{
    public class ProductPartValidator : AbstractValidator<ProductPart>
    {
        public ProductPartValidator()
        {
            // TODO
        }
    }
}