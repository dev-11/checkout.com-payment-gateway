using FluentValidation;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Validators
{
    public class CardDtoValidator : AbstractValidator<CardDto>
    {
        public CardDtoValidator()
        {
            RuleFor(x => x.Cvv).InclusiveBetween(100, 999);
            RuleFor(x => x.ExpiryMonth).InclusiveBetween(1, 12);
            RuleFor(x => x.ExpiryYear).InclusiveBetween(00, 99);
            RuleFor(x => x.CardNumber).NotNull().NotEmpty().CreditCard();
        }
    }
}