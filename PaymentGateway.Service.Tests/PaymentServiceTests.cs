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
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.PaymentRepositoryForEmptyRequest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock);

            var response = service.ProcessPayment(Mocks.Mock.For.PaymentServiceTests.EmptyRequest);

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void ProcessPayment_ReturnsEmptyResponseOnNullRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.PaymentRepositoryForEmptyRequest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock);

            var response = service.ProcessPayment(null);

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void ProcessPayment_ReturnsSuccessfulResponseForRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.GeneralPaymentRepository,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock);

            var response = service.ProcessPayment(new PaymentRequest
            {
                Amount = 50,
                Card = new Card
                {
                    Cvv = 123,
                    CardNumber = "4716171572210785",
                    ExpiryYear = 20,
                    ExpiryMonth = 12
                },
                Currency = "GBP"
            });

            response.Should().NotBeNull();
            response.PaymentId.Should().NotBe(Guid.Empty);
            response.PaymentId.Should().Be("85a47a09-3fd8-4843-b161-ded7a970b286");
            response.IsRequestSucceeded.Should().BeTrue();
        }

        [Fact]
        public void ProcessPayment_ReturnsUnsuccessfulResponseForRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.GeneralPaymentRepository,
                Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock);

            var response = service.ProcessPayment(new PaymentRequest
            {
                Amount = 1000,
                Card = new Card
                {
                    Cvv = 123,
                    CardNumber = "4716171572210785",
                    ExpiryYear = 20,
                    ExpiryMonth = 12
                },
                Currency = "GBP"
            });

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }
    }
}