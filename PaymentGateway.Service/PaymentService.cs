using System;
using PaymentGateway.Service.Clients;

namespace PaymentGateway.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IBankClient _bankClient;

        public PaymentService(IPaymentRepository repository, IBankClient bankClient)
        {
            _repository = repository;
            _bankClient = bankClient;
        }

        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest is null)
            {
                return new PaymentResponse
                {
                    IsRequestSucceeded = false
                };
            }

            var bankResponse = _bankClient.ProcessTransaction(new BankTransactionRequestDto
            {
                Amount = paymentRequest.Amount
            });

            if (!bankResponse.IsTransactionSuccessful)
            {
                return new PaymentResponse
                {
                    IsRequestSucceeded = false
                };
            }

            return _repository.SavePayment(paymentRequest);
        }
    }
}