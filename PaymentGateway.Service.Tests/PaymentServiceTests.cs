using System;
using FluentAssertions;
using PaymentGateway.Service.Dom;
using Xunit;

namespace PaymentGateway.Service.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void ProcessPayment_ReturnsEmptyResponseOnEmptyRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.PaymentRepositoryForEmptyRequest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapperMapsToEmpty);

            var response = service.ProcessPayment(Mocks.Mock.For.PaymentServiceTests.EmptyRequest);

            response.Should().NotBeNull();
            response.PaymentId.Should().Be(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void ProcessPayment_ReturnsSuccessfulResponseForRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentServiceTests.GeneralPaymentRepository,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

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
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapperForFalseTransaction);

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
            response.PaymentId.Should().NotBe(Guid.Empty);
            response.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnsEmptyResponseOnEmptyRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForEmptyRequest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(Mocks.Mock.For.PaymentHistoryServiceTests.EmptyGuid);

            response.Should().NotBeNull();
            response.Amount.Should().Be(default(double));
            response.Currency.Should().Be(default(string));
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(default(int));
            response.Card.CardNumber.Should().Be(default(string));
            response.Card.ExpiryMonth.Should().Be(default(int));
            response.Card.ExpiryYear.Should().Be(default(int));
            response.Id.Should().Be(Guid.Empty);
            response.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnEmptyResponseOnRequestWithNotExistingId()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForNotFoundTest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Amount.Should().Be(default(double));
            response.Currency.Should().Be(default(string));
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(default(int));
            response.Card.CardNumber.Should().Be(default(string));
            response.Card.ExpiryMonth.Should().Be(default(int));
            response.Card.ExpiryYear.Should().Be(default(int));
            response.Id.Should().Be(Guid.Empty);
            response.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnsCorrectResponseOnRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.GeneralPaymentRepository,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Amount.Should().Be(12);
            response.Currency.Should().Be("GBP");
            response.Card.Should().NotBeNull();
            response.Card.Cvv.Should().Be(123);
            response.Card.CardNumber.Should().Be("4716171572210785");
            response.Card.ExpiryMonth.Should().Be(11);
            response.Card.ExpiryYear.Should().Be(20);
            response.Id.Should().Be("24b542a8-4825-4089-ace6-6c0ef8bd56a8");
            response.IsSuccessful.Should().BeTrue();
        }
    }
}