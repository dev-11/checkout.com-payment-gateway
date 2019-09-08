using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service
{
    public interface IPaymentRepository
    {
        Payment Get(Guid id);
        Guid Save(Payment payment);
    }
}