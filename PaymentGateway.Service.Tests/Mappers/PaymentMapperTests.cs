using System;
using FluentAssertions;
using PaymentGateway.Service.Dom;
using PaymentGateway.Service.Mappers;
using Xunit;

namespace PaymentGateway.Service.Tests.Mappers
{
    public class PaymentMapperTests
    {
        [Fact]
        public void MapperMapsEveryPropertyProperly()
        {
            var id = new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8");
            var paymentRequest = new PaymentRequest
            {
                Amount = 1,
                Currency = "GBP",
                Card = new Card
                {
                    CardNumber = "1234123412341234",
                    Cvv = 123,
                    ExpiryMonth = 12,
                    ExpiryYear = 20
                }
            };

            var paymentMapper = new PaymentMapper();

            var mappedObject = paymentMapper.Map(id, true, paymentRequest);

            mappedObject.Should().NotBeNull();
            mappedObject.Id.Should().Be(id);
            mappedObject.IsSuccessful.Should().BeTrue();
            mappedObject.Card.Should().NotBeNull();
            mappedObject.Card.Cvv.Should().Be(123);
            mappedObject.Card.CardNumber.Should().Be("1234123412341234");
            mappedObject.Card.ExpiryMonth.Should().Be(12);
            mappedObject.Card.ExpiryYear.Should().Be(20);
            mappedObject.Amount.Should().Be(1);
            mappedObject.Currency.Should().Be("GBP");
        }

        [Fact]
        public void MapperMapsNullToEmptyObject()
        {
            var paymentMapper = new PaymentMapper();

            var mappedObject = paymentMapper.Map(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"), false, null);

            mappedObject.Should().NotBeNull();
            mappedObject.Id.Should().Be(Guid.Empty);
            mappedObject.IsSuccessful.Should().BeFalse();
            mappedObject.Card.Should().NotBeNull();
            mappedObject.Card.Cvv.Should().Be(default(int));
            mappedObject.Card.CardNumber.Should().Be(default(string));
            mappedObject.Card.ExpiryMonth.Should().Be(default(int));
            mappedObject.Card.ExpiryYear.Should().Be(default(int));
            mappedObject.Amount.Should().Be(default(double));
            mappedObject.Currency.Should().Be(default(string));
        }
    }
}