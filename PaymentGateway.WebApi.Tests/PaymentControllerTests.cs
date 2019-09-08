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
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.PaymentDtoMapper,
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

        [Fact]
        public void ProcessPaymentReturnsBadRequestForInvalidModelState()
        {
            var controller = new PaymentController(Mocks.Mock.For.PaymentPaymentControllerTests.RequestMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.ResponseMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.PaymentDtoMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.PaymentService);

            controller.ModelState.AddModelError("InvalidModel", "Test model error");
            var response = controller.RequestPayment(new PaymentRequestDto());

            response.Should().NotBeNull();
            response.GetType().Should().Be(typeof(BadRequestObjectResult));
            var httpResult = (BadRequestObjectResult) response;
            httpResult.StatusCode.HasValue.Should().BeTrue();
            httpResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public void GetPaymentReturnsOkWithFilledPaymentOnRequest()
        {
            var expectedPaymentDto = new PaymentDto
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
            };

            var controller = new PaymentController(Mocks.Mock.For.PaymentPaymentControllerTests.RequestMapper,
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.ResponseMapper,
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.PaymentDtoMapper,
                                                   Mocks.Mock.For.PaymentPaymentControllerTests.PaymentService);

            var response = controller.GetPayment(new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"));

            response.Should().NotBeNull();
            response.GetType().Should().Be(typeof(OkObjectResult));
            var httpResult = (OkObjectResult) response;
            httpResult.StatusCode.HasValue.Should().BeTrue();
            httpResult.StatusCode.Should().Be(200);
            ((OkObjectResult) response).Value.GetType().Should().Be(typeof(PaymentDto));
            ((PaymentDto) ((OkObjectResult) response).Value).Should().BeEquivalentTo(expectedPaymentDto);
        }

        [Fact]
        public void GetPaymentReturnsBadRequestOnEmptyGuid()
        {
            var controller = new PaymentController(Mocks.Mock.For.PaymentPaymentControllerTests.RequestMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.ResponseMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.PaymentDtoMapper,
                Mocks.Mock.For.PaymentPaymentControllerTests.PaymentService);

            var response = controller.GetPayment(Guid.Empty);

            response.Should().NotBeNull();
            response.GetType().Should().Be(typeof(BadRequestObjectResult));
            var httpResult = (BadRequestObjectResult) response;
            httpResult.StatusCode.HasValue.Should().BeTrue();
            httpResult.StatusCode.Value.Should().Be(400);
        }
    }
}