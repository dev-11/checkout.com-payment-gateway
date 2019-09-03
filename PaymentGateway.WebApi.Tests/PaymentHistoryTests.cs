using System;
using FluentAssertions;
using PaymentGateway.WebApi.Controllers;
using Xunit;

namespace PaymentGateway.WebApi.Tests
{
    public class PaymentHistoryTests
    {
        [Fact]
        public void Test01()
        {
            var controller = new PaymentHistoryController();
            var v = controller.Get(Guid.Empty);
            v.Result.Should().Be(Guid.Empty);
        }
    }
}