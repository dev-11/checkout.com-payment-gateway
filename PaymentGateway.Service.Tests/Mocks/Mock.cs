using System;
using Moq;
using PaymentGateway.Service.Clients;

namespace PaymentGateway.Service.Tests.Mocks
{
    public static class Mock
    {
        public static class For
        {
            public static class PaymentHistoryServiceTests
            {
                public static Guid EmptyGuid => Guid.Empty;

                public static IPaymentRepository PaymentRepositoryForEmptyRequest
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.GetPaymentHistory(It.IsAny<Guid>()))
                            .Returns(new PaymentHistoryResponse
                            {
                                Card = new Card()
                            });

                        return mock.Object;
                    }
                }

                public static IPaymentRepository PaymentRepositoryForNotFoundTest
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.GetPaymentHistory(It.IsAny<Guid>()))
                            .Returns(new PaymentHistoryResponse
                            {
                                Card = new Card()
                            });

                        return mock.Object;
                    }
                }

                public static IPaymentRepository GeneralPaymentRepository
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.GetPaymentHistory(It.IsAny<Guid>()))
                            .Returns(new PaymentHistoryResponse
                            {
                                Card = new Card
                                {
                                    CardNumber = "4716171572210785",
                                    Cvv = 123,
                                    ExpiryMonth = 11,
                                    ExpiryYear = 20
                                },
                                Amount = 12,
                                Currency = "GBP"
                            });

                        return mock.Object;
                    }
                }
            }

            public static class PaymentServiceTests
            {
                public static PaymentRequest EmptyRequest => new PaymentRequest
                {
                    Card = new Card()
                };

                public static IPaymentRepository PaymentRepositoryForEmptyRequest
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.SavePayment(It.IsAny<PaymentRequest>()))
                            .Returns(new PaymentResponse());

                        return mock.Object;
                    }
                }

                public static IPaymentRepository GeneralPaymentRepository
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.SavePayment(It.IsAny<PaymentRequest>()))
                            .Returns(new PaymentResponse
                            {
                                PaymentId = new Guid("85a47a09-3fd8-4843-b161-ded7a970b286"),
                                IsRequestSucceeded = true
                            });

                        return mock.Object;
                    }
                }


                public static IBankClient GeneralBankClientMock
                {
                    get
                    {
                        var mock = new Mock<IBankClient>();
                        mock.Setup(x => x.ProcessTransaction(It.IsAny<BankTransactionRequestDto>()))
                            .Returns((BankTransactionRequestDto request) =>
                            {
                                if (request is null)
                                {
                                    return new BankTransactionResponseDto
                                    {
                                        IsTransactionSuccessful = false
                                    };
                                }

                                return new BankTransactionResponseDto
                                {
                                    IsTransactionSuccessful = request.Amount <= 100
                                };
                            });

                        return mock.Object;
                    }
                }
            }
        }
    }
}