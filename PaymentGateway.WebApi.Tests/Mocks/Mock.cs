using System;
using Moq;
using PaymentGateway.Service;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Tests.Mocks
{
    public static class Mock
    {
        public static class For
        {
            public static class PaymentPaymentControllerTests
            {
                public static Guid EmptyGuid => Guid.Empty;

                public static IPaymentService PaymentService
                {
                    get
                    {
                        var mock = new Mock<IPaymentService>();
                        mock.Setup(x => x.ProcessPayment(It.IsAny<PaymentRequest>()))
                            .Returns(new PaymentResponse
                            {
                                IsRequestSucceeded = true,
                                PaymentId = Guid.NewGuid()
                            });

                        return mock.Object;
                    }
                }

                public static IMapper<PaymentRequest, PaymentRequestDto> RequestMapper
                {
                    get
                    {
                        var mock = new Mock<IMapper<PaymentRequest, PaymentRequestDto>>();
                        mock.Setup(x => x.Map(It.IsAny<PaymentRequestDto>()))
                            .Returns(new PaymentRequest());

                        return mock.Object;
                    }
                }
                
                public static IMapper<PaymentResponse, PaymentResponseDto> ResponseMapper
                {
                    get
                    {
                        var mock = new Mock<IMapper<PaymentResponse, PaymentResponseDto>>();
                        mock.Setup(x => x.Map(It.IsAny<PaymentResponse>()))
                            .Returns(new PaymentResponseDto
                            {
                                PaymentId = Guid.NewGuid(),
                                IsRequestSucceeded = true
                            });

                        return mock.Object;
                    }
                }
            }
        }
    }
}