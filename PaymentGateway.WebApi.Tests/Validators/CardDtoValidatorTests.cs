using FluentValidation.TestHelper;
using PaymentGateway.WebApi.Validators;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Validators
{
    public class CardDtoValidatorTests
    {
        [Fact]
        public void CardValidatorHasNoErrorForMinCvv()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.Cvv, 100);
        }

        [Fact]
        public void CardValidatorHasNoErrorForMaxCvv()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.Cvv, 999);
        }

        [Fact]
        public void CardValidatorHasErrorForTooSmallCvv()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Cvv, 99);
        }

        [Fact]
        public void CardValidatorHasErrorForBigLowCvv()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Cvv, 1000);
        }

        [Fact]
        public void CardValidatorHasNoErrorForMinExpiryMonth()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.ExpiryMonth, 1);
        }

        [Fact]
        public void CardValidatorHasNoErrorForMaxExpiryMonth()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.ExpiryMonth, 12);
        }

        [Fact]
        public void CardValidatorHasErrorForTooSmallExpiryMonth()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.ExpiryMonth, 0);
        }

        [Fact]
        public void CardValidatorHasErrorForTooBigExpiryMonth()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.ExpiryMonth, 13);
        }

        [Fact]
        public void CardValidatorHasNoErrorForTooMinExpiryYear()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.ExpiryYear, 0);
        }

        [Fact]
        public void CardValidatorHasNoErrorForTooMaxExpiryYear()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.ExpiryYear, 99);
        }

        [Fact]
        public void CardValidatorHasErrorForTooSmallExpiryYear()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.ExpiryYear, -1);
        }

        [Fact]
        public void CardValidatorHasErrorForTooBigExpiryYear()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.ExpiryMonth, 100);
        }

        [Fact]
        public void CardValidatorHasErrorForNullCarNumber()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.CardNumber, null as string);
        }

        [Fact]
        public void CardValidatorHasErrorForEmptyCarNumber()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.CardNumber, string.Empty);
        }

        [Fact]
        public void CardValidatorHasErrorForTextCarNumber()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.CardNumber, "text in string");
        }

        [Fact]
        public void CardValidatorHasNoErrorForValidCarNumberSeparatedBySpace()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.CardNumber, "4500 4677 1782 4385");
        }

        [Fact]
        public void CardValidatorHasNoErrorForValidCarNumberSeparatedByDash()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.CardNumber, "4500-4677-1782-4385");
        }

        [Fact]
        public void CardValidatorHasNoErrorForValidCarNumber()
        {
            var validator = new CardDtoValidator();
            validator.ShouldNotHaveValidationErrorFor(x => x.CardNumber, "4500467717824385");
        }

        [Fact]
        public void CardValidatorHasErrorForInvalidCarNumber()
        {
            var validator = new CardDtoValidator();
            validator.ShouldHaveValidationErrorFor(x => x.CardNumber, "4500 4677 1782 4384");
        }
    }
}