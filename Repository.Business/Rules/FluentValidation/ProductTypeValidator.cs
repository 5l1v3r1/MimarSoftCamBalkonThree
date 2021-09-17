using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.Rules.FluentValidation
{
    public class ProductTypeValidator : AbstractValidator<ProductType>
    {
        public ProductTypeValidator()
        {
            // TODO
        }
    }
}