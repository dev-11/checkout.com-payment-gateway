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
            response.Result.Should().NotBeNull();
            response.Result.PaymentId.Should().Be(Guid.Empty);
            response.Result.IsRequestSucceeded.Should().BeFalse();
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
            response.Result.Should().NotBeNull();
            response.Result.PaymentId.Should().NotBe(Guid.Empty);
            response.Result.PaymentId.Should().Be("85a47a09-3fd8-4843-b161-ded7a970b286");
            response.Result.IsRequestSucceeded.Should().BeTrue();
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
            response.Result.Should().NotBeNull();
            response.Result.PaymentId.Should().NotBe(Guid.Empty);
            response.Result.IsRequestSucceeded.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnsEmptyResponseOnEmptyRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForEmptyRequest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(Mocks.Mock.For.PaymentHistoryServiceTests.EmptyGuid);

            response.Should().NotBeNull();
            response.Result.Should().NotBeNull();
            response.Result.Amount.Should().Be(default(double));
            response.Result.Currency.Should().Be(default(string));
            response.Result.Card.Should().NotBeNull();
            response.Result.Card.Cvv.Should().Be(default(int));
            response.Result.Card.CardNumber.Should().Be(default(string));
            response.Result.Card.ExpiryMonth.Should().Be(default(int));
            response.Result.Card.ExpiryYear.Should().Be(default(int));
            response.Result.Id.Should().Be(Guid.Empty);
            response.Result.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnEmptyResponseOnRequestWithNotExistingId()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.PaymentRepositoryForNotFoundTest,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Result.Should().NotBeNull();
            response.Result.Amount.Should().Be(default(double));
            response.Result.Currency.Should().Be(default(string));
            response.Result.Card.Should().NotBeNull();
            response.Result.Card.Cvv.Should().Be(default(int));
            response.Result.Card.CardNumber.Should().Be(default(string));
            response.Result.Card.ExpiryMonth.Should().Be(default(int));
            response.Result.Card.ExpiryYear.Should().Be(default(int));
            response.Result.Id.Should().Be(Guid.Empty);
            response.Result.IsSuccessful.Should().BeFalse();
        }

        [Fact]
        public void GetPayment_ReturnsCorrectResponseOnRequest()
        {
            var service = new PaymentService(Mocks.Mock.For.PaymentHistoryServiceTests.GeneralPaymentRepository,
                                             Mocks.Mock.For.PaymentServiceTests.GeneralBankClientMock,
                                             Mocks.Mock.For.PaymentServiceTests.PaymentMapper);

            var response = service.GetPayment(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.Result.Should().NotBeNull();
            response.Result.Amount.Should().Be(12);
            response.Result.Currency.Should().Be("GBP");
            response.Result.Card.Should().NotBeNull();
            response.Result.Card.Cvv.Should().Be(123);
            response.Result.Card.CardNumber.Should().Be("4716171572210785");
            response.Result.Card.ExpiryMonth.Should().Be(11);
            response.Result.Card.ExpiryYear.Should().Be(20);
            response.Result.Id.Should().Be("24b542a8-4825-4089-ace6-6c0ef8bd56a8");
            response.Result.IsSuccessful.Should().BeTrue();
        }
    }
}