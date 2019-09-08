using FluentValidation.TestHelper;
using PaymentGateway.WebApi.Validators;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Validators
{
    public class PaymentRequestDtoValidatorTests
    {
        [Fact]
        public void PaymentRequestDtoValidatorCardPropertyHasChildValidator()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveChildValidator(x => x.Card, typeof(CardDtoValidator));
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasNoErrorForMinAmount()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.Amount, 0.01);
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasNoErrorForMaxAmount()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.Amount, double.MaxValue);
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasErrorForTooSmallAmount()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Amount, 0.001);
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasErrorNullCurrency()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Currency, null as string);
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasErrorEmptyCurrency()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Currency, string.Empty);
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasErrorTooShortCurrency()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Currency, "1");
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasNoErrorTooShortCurrency()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.Currency, "GBP");
        }

        [Fact]
        public void PaymentRequestDtoValidatorHasErrorTooLongCurrency()
        {
            var validator = new PaymentRequestDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Currency, "GBPP");
        }

    }
}