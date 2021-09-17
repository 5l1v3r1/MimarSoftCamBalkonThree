using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.Rules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // TODO
        }
    }
}