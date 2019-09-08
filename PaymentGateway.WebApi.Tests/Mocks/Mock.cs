using System;
using Moq;
using PaymentGateway.Service;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
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

                public static IMapper<PaymentRequestDto, PaymentRequest> RequestMapper
                {
                    get
                    {
                        var mock = new Mock<IMapper<PaymentRequestDto, PaymentRequest>>();
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

                public static IMapper<Payment, PaymentDto> PaymentDtoMapper
                {
                    get
                    {
                        var mock = new Mock<IMapper<Payment, PaymentDto>>();
                        mock.Setup(x => x.Map(It.IsAny<Payment>()))
                            .Returns(new PaymentDto
                            {
                                Amount = 1,
                                Currency = "GBP",
                                Card = new CardDto
                                {
                                    CardNumber = "1234123412341234",
                                    Cvv = 123,
                                    ExpiryMonth = 12,
                                    ExpiryYear = 20
                                },
                                Id = new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"),
                                IsSuccessful = true
                            });

                        return mock.Object;
                    }
                }
            }
        }
    }
}