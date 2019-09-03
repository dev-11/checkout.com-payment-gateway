namespace PaymentGateway.Service
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
    }
}