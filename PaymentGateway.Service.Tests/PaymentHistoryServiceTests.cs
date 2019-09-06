using System;
using FluentAssertions;
using Xunit;

namespace PaymentGateway.Service.Tests
{
    public class PaymentHistoryServiceTests
    {
        [Fact]
        public void GetPaymentHistory_ReturnsEmptyResponseOnEmptyRequest()
        {
            var service = new PaymentHistoryService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForEmptyRequest);

            var response = service.GetPaymentHistory(Mocks.Mock.For.PaymentHistoryServiceTests.EmptyGuid);

            response.Should().NotBeNull();
            response.Amount.Should().Be(default(double));
            response.Currency.Should().Be(default(string));
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(default(int));
            response.Card.CardNumber.Should().Be(default(string));
            response.Card.ExpiryMonth.Should().Be(default(int));
            response.Card.ExpiryYear.Should().Be(default(int));
        }

        [Fact]
        public void GetPaymentHistory_ReturnEmptyResponseOnRequestWithNotExistingId()
        {
            var service = new PaymentHistoryService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForNotFoundTest);

            var response = service.GetPaymentHistory(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Amount.Should().Be(default(double));
            response.Currency.Should().Be(default(string));
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(default(int));
            response.Card.CardNumber.Should().Be(default(string));
            response.Card.ExpiryMonth.Should().Be(default(int));
            response.Card.ExpiryYear.Should().Be(default(int));
        }

        [Fact]
        public void GetPaymentHistory_ReturnsCorrectResponseOnRequest()
        {
            var service = new PaymentHistoryService(Mocks.Mock.For.PaymentHistoryServiceTests.GeneralPaymentRepository);

            var response = service.GetPaymentHistory(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Amount.Should().Be(12);
            response.Currency.Should().Be("GBP");
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(123);
            response.Card.CardNumber.Should().Be("4716171572210785");
            response.Card.ExpiryMonth.Should().Be(11);
            response.Card.ExpiryYear.Should().Be(20);
        }
    }
}