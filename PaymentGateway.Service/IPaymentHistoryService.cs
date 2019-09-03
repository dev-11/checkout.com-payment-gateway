using System;

namespace PaymentGateway.Service
{
    public interface IPaymentHistoryService
    {
        PaymentHistoryResponse GetPaymentHistory(Guid paymentId);
    }
}