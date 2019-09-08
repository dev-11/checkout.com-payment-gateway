using FluentValidation;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Validators
{
    public class PaymentRequestDtoValidator: AbstractValidator<PaymentRequestDto>
    {
        public PaymentRequestDtoValidator()
        {
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0.01);
            RuleFor(x => x.Currency).NotNull().NotEmpty().Length(3);
            RuleFor(x => x.Card).SetValidator(new CardDtoValidator());
        }
    }
}