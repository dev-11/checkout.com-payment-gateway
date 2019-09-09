namespace PaymentGateway.Service.Dom
{
    /// <summary>
    /// Debit/credit card object
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The number of the card
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The expiry month of the card
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card
        /// </summary>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// The cvv of the card
        /// </summary>
        public int Cvv { get; set; }

        /// <summary>
        /// Empty object for null object pattern
        /// </summary>
        public static Card Empty => new Card();
    }
}