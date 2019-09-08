namespace PaymentGateway.WebApi.Models
{
    public class CardDto
    {
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
        
        public static CardDto Empty => new CardDto();
    }
}