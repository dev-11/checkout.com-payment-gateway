using System;
using Moq;

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
            }
        }
    }
}