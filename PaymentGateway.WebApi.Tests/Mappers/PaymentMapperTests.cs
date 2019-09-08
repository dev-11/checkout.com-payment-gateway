using System;
using FluentAssertions;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Mappers
{
    public class PaymentMapperTests
    {
        [Fact]
        public void MapperMapsPaymentToPaymentDto()
        {
            var guid = new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8");

            var payment = new Payment
            {
                Amount = 1,
                Currency = "GBP",
                Card = new Card
                {
                    CardNumber = "1234123412341234",
                    Cvv = 123,
                    ExpiryMonth = 12,
                    ExpiryYear = 20
                },
                Id = guid,
                IsSuccessful = true
            };

            var mapper = new PaymentMapper(new CardMapper());
            var mappedObject = mapper.Map(payment);

            mappedObject.Should().NotBeNull();
            mappedObject.Id.Should().Be(guid);
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
        public void MapperMapsNullPaymentToEmptyDto()
        {
            var mapper = new PaymentMapper(null);

            var mappedObject = mapper.Map(null);

            mappedObject.Should().NotBeNull();
            mappedObject.Should().BeEquivalentTo(PaymentDto.Empty);
        }
    }
}