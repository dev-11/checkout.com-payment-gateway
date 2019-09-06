using System;
using FluentAssertions;
using Xunit;

namespace PaymentGateway.Service.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void ProcessPayment_ReturnsEmptyResponseOnEmptyRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.PaymentRepositoryForEmptyRequest);

            var response = service.ProcessPayment(Mocks.Mock.For.PaymentServiceTests.EmptyRequest);

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void ProcessPayment_ReturnsEmptyResponseOnNullRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.PaymentRepositoryForEmptyRequest);

            var response = service.ProcessPayment(null);

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }
    }
}