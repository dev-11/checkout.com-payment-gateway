using FluentAssertions;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Mappers
{
    public class PaymentRequestMapperTests
    {
        [Fact]
        public void MapperMapsNullDtoToEmptyRequest()
        {
            var mapper = new PaymentRequestDtoMapper(new CardMapper());
            var mappedObject = mapper.Map(null);

            mappedObject.Should().NotBeNull();
            mappedObject.Should().BeEquivalentTo(PaymentRequest.Empty);
        }

        [Fact]
        public void MapperMapsRequestDtoToRequest()
        {
            var paymentRequest = new PaymentRequestDto
            {
                Amount = 1,
                Currency = "GBP",
                Card = new CardDto
                {
                    CardNumber = "1234123412341234",
                    Cvv = 123,
                    ExpiryMonth = 12,
                    ExpiryYear = 20
                }
            };

            var mapper = new PaymentRequestDtoMapper(new CardMapper());
            var mappedObject = mapper.Map(paymentRequest);

            mappedObject.Should().NotBeNull();
            mappedObject.Card.Should().NotBeNull();
            mappedObject.Card.Cvv.Should().Be(123);
            mappedObject.Card.CardNumber.Should().Be("1234123412341234");
            mappedObject.Card.ExpiryMonth.Should().Be(12);
            mappedObject.Card.ExpiryYear.Should().Be(20);
            mappedObject.Amount.Should().Be(1);
            mappedObject.Currency.Should().Be("GBP");
        }
    }
}