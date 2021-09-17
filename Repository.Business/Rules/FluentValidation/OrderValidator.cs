using FluentValidation;
using Repository.Entities.Concrete;

namespace Repository.Business.Rules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            // TODO
        }
    }
}