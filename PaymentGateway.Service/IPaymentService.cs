using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
        Payment GetPayment(Guid paymentId);

    }
}