using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.WebApi.Controllers;
using PaymentGateway.WebApi.Models;
using Xunit;

namespace PaymentGateway.WebApi.Tests
{
    public class PaymentControllerTests
    {
        [Fact]
        public void ProcessPaymentReturnsOkWithFilledPayloadOnRequest()
        {
            var controller = new PaymentController(Mocks.Mock.For.PaymentPaymentControllerTests.RequestMapper,
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.ResponseMapper,
                                                   null,
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.PaymentService);

            var response = controller.RequestPayment(new PaymentRequestDto
            {
                Currency = "GBP",
                Amount = 12,
                Card = new CardDto
                {
                    CardNumber = "1234123412341234",
                    Cvv = 123,
                    ExpiryMonth = 12,
                    ExpiryYear = 20
                }
            });

            response.Should().NotBeNull();
            response.GetType().Should().Be(typeof(OkObjectResult));
            var httpResult = (OkObjectResult) response;
            httpResult.StatusCode.HasValue.Should().BeTrue();
            httpResult.StatusCode.Should().Be(200);
            ((OkObjectResult) response).Value.GetType().Should().Be(typeof(PaymentResponseDto));
            var payload = (PaymentResponseDto) ((OkObjectResult) response).Value;
            payload.PaymentId.Should().NotBe(Guid.Empty);
            payload.IsRequestSucceeded.Should().BeTrue();
        }
    }
}