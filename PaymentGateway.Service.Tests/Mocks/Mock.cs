using System;
using Moq;
using PaymentGateway.Service.Clients;
using PaymentGateway.Service.Dom;
using PaymentGateway.Service.Mappers;

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
                        mock.Setup(x => x.Get(It.IsAny<Guid>()))
                            .Returns(new Payment
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
                        mock.Setup(x => x.Get(It.IsAny<Guid>()))
                            .Returns(new Payment
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
                        mock.Setup(x => x.Get(It.IsAny<Guid>()))
                            .Returns(new Payment
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
                        mock.Setup(x => x.Save(It.IsAny<Payment>()))
                            .Returns(Guid.Empty);

                        return mock.Object;
                    }
                }

                public static IPaymentRepository GeneralPaymentRepository
                {
                    get
                    {
                        var mock = new Mock<IPaymentRepository>();
                        mock.Setup(x => x.Save(It.IsAny<Payment>()))
                            .Returns(new Guid("85a47a09-3fd8-4843-b161-ded7a970b286"));

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

                public static IPaymentMapper PaymentMapper
                {
                    get
                    {
                        var mock = new Mock<IPaymentMapper>();
                        mock.Setup(x => x.Map(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<PaymentRequest>()))
                            .Returns(new Payment
                            {
                                Amount = 1,
                                Currency = "currency",
                                Card = new Card
                                {
                                    CardNumber = "1234123412341234",
                                    Cvv = 123,
                                    ExpiryMonth = 12,
                                    ExpiryYear = 20
                                },
                                IsSuccessful = true
                            });

                        return mock.Object;
                    }
                }

                public static IPaymentMapper PaymentMapperForFalseTransaction
                {
                    get
                    {
                        var mock = new Mock<IPaymentMapper>();
                        mock.Setup(x => x.Map(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<PaymentRequest>()))
                            .Returns(new Payment
                            {
                                Amount = 1,
                                Currency = "currency",
                                Card = new Card
                                {
                                    CardNumber = "1234123412341234",
                                    Cvv = 123,
                                    ExpiryMonth = 12,
                                    ExpiryYear = 20
                                },
                                IsSuccessful = false
                            });

                        return mock.Object;
                    }
                }

                public static IPaymentMapper PaymentMapperMapsToEmpty
                {
                    get
                    {
                        var mock = new Mock<IPaymentMapper>();
                        mock.Setup(x => x.Map(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<PaymentRequest>()))
                            .Returns(Payment.Empty);

                        return mock.Object;
                    }
                }
            }
        }
    }
}