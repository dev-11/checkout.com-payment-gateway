namespace PaymentGateway.Service.Dom
{
    public class PaymentRequest
    {
        public Card Card { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        public static PaymentRequest Empty => new PaymentRequest
        {
            Card = Card.Empty
        };
    }
}