using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service.Mappers
{
    public class PaymentMapper : IPaymentMapper
    {
        public Payment Map(Guid id, bool isSuccessful, PaymentRequest paymentRequest)
        {
            if (paymentRequest is null)
            {
                return Payment.Empty;
            }

            return new Payment
            {
                Id = id,
                Amount = paymentRequest.Amount,
                Currency = paymentRequest.Currency,
                Card = paymentRequest.Card,
                IsSuccessful = isSuccessful
            };
        }
    }
}