using System;

namespace PaymentGateway.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest is null)
            {
                return new PaymentResponse
                {
                    PaymentId = Guid.Empty,
                    IsRequestSucceeded = false
                };
            }

            return _repository.SavePayment(paymentRequest);
        }
    }
}