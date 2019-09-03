using FluentAssertions;
using PaymentGateway.WebApi.Controllers;
using Xunit;

namespace PaymentGateway.WebApi.Tests
{
    public class PaymentControllerTests
    {
        [Fact]
        public void Test1()
        {
            var controller = new PaymentController();
            var v = controller.Index(1);
            v.Result.Should().Be(1);
        }
    }
}