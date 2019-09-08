using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service.Mappers
{
    public interface IPaymentMapper
    {
        Payment Map(Guid id, bool isSuccessful, PaymentRequest paymentRequest);
    }
}