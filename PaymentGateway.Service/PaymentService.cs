using System;
using System.Threading.Tasks;
using PaymentGateway.Service.Clients;
using PaymentGateway.Service.Dom;
using PaymentGateway.Service.Mappers;

namespace PaymentGateway.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IBankClient _bankClient;
        private readonly IPaymentMapper _paymentMapper;

        public PaymentService(IPaymentRepository repository, IBankClient bankClient, IPaymentMapper paymentMapper)
        {
            _repository = repository;
            _bankClient = bankClient;
            _paymentMapper = paymentMapper;
        }

        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
        {
            var bankResponse = await _bankClient.ProcessTransaction(new BankTransactionRequestDto
            {
                Amount = paymentRequest.Amount
            });

            var payment = _paymentMapper.Map(Guid.Empty, bankResponse.IsTransactionSuccessful, paymentRequest);

            var id = await _repository.Save(payment);
            return new PaymentResponse
            {
                PaymentId = id,
                IsRequestSucceeded = payment.IsSuccessful
            };
        }

        public async Task<Payment> GetPayment(Guid paymentId)
        {
            return paymentId == Guid.Empty ? Payment.Empty : await _repository.Get(paymentId);
        }
    }
}