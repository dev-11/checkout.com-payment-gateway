using System;

namespace PaymentGateway.Service
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentHistoryService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentHistoryResponse GetPaymentHistory(Guid paymentId)
        {
            if (paymentId == Guid.Empty)
            {
                return new PaymentHistoryResponse
                {
                    Card = new Card()
                };
            }

            return _paymentRepository.GetPaymentHistory(paymentId);
        }
    }
}