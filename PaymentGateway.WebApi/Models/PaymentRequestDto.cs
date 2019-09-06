namespace PaymentGateway.WebApi.Models
{
    public class PaymentRequestDto
    {
        public CardDto Card { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}