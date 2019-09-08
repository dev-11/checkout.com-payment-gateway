using System;
using FluentAssertions;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Mappers
{
    public class PaymentResponseMapperTests
    {
        [Fact]
        public void Test01()
        {
            var expectedObject = new PaymentResponseDto();

            var mapper = new PaymentResponseMapper();
            var mappedObject = mapper.Map(null);

            mappedObject.Should().NotBeNull();
            mappedObject.Should().BeEquivalentTo(expectedObject);
        }

        [Fact]
        public void Test02()
        {
            var objectToMap = new PaymentResponse
            {
                PaymentId = new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"),
                IsRequestSucceeded = true
            };
            
            var expectedObject = new PaymentResponseDto
            {
                PaymentId = new Guid("24b542a8-4825-4089-ace6-6c0ef8bd56a8"),
                IsRequestSucceeded = true
            };
            
            var mapper = new PaymentResponseMapper();
            var mappedObject = mapper.Map(objectToMap);

            mappedObject.Should().NotBeNull();
            mappedObject.Should().BeEquivalentTo(expectedObject);
        }
    }
}