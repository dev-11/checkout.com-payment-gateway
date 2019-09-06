using System;

namespace PaymentGateway.Service
{
    public interface IPaymentRepository
    {
        PaymentHistoryResponse GetPaymentHistory(Guid id);
        PaymentResponse SavePayment(PaymentRequest paymentRequest);
    }
}