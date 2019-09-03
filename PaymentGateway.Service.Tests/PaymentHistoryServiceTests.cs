using System;
using Xunit;

namespace PaymentGateway.Service.Tests
{
    public class PaymentHistoryServiceTests
    {
        [Fact]
        public void NotImplementedExceptionIsBeingThrown()
        {
            var service = new PaymentHistoryService();

            Action act = () => service.GetPaymentHistory(new Guid());

            Assert.Throws<NotImplementedException>(act);
        }
    }
}