namespace PaymentGateway.Service.Dom
{
    public class Card
    {
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }

        public static Card Empty => new Card();
    }
}