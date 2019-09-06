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
    }
}