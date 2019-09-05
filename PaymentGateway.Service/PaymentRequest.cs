namespace PaymentGateway.Service
{
    public class PaymentRequest
    {
        public Card Card { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}