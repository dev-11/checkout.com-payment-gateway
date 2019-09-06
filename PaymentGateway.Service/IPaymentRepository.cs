using System;

namespace PaymentGateway.Service
{
    public interface IPaymentRepository
    {
        PaymentHistoryResponse GetPaymentHistory(Guid id);
        PaymentResponse SavePayment(PaymentRequest paymentRequest);
    }

    public class PaymentRepository : IPaymentRepository
    {
        public PaymentHistoryResponse GetPaymentHistory(Guid id)
        {
            return new PaymentHistoryResponse
            {
                Amount = 1,
                Card = new Card
                {
                    CardNumber = "asdf",
                    ExpiryYear = 1999,
                    ExpiryMonth = 32,
                    Cvv = 111
                }
            };
        }

        public PaymentResponse SavePayment(PaymentRequest paymentRequest)
        {
            return new PaymentResponse
            {
                PaymentId = Guid.NewGuid(),
                IsRequestSucceeded = true
            };
        }
    }
}