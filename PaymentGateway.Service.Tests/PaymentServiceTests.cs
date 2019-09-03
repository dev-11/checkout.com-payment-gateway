using System;
using Xunit;

namespace PaymentGateway.Service.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void NotImplementedExceptionIsBeingThrown()
        {
            var service = new PaymentService();

            Action act = () => service.ProcessPayment(new PaymentRequest());

            Assert.Throws<NotImplementedException>(act);
        }

    }
}