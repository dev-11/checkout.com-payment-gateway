namespace PaymentGateway.Service.Dom
{
    /// <summary>
    /// The payment request
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// The card of the request
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// The amount of the request
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// The currency of the request
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Empty object for null object pattern
        /// </summary>
        public static PaymentRequest Empty => new PaymentRequest
        {
            Card = Card.Empty
        };
    }
}