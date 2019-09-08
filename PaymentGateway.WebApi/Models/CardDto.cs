namespace PaymentGateway.WebApi.Models
{
    /// <summary>
    /// Bank card, credit card object
    /// </summary>
    public class CardDto
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
        public static CardDto Empty => new CardDto();
    }
}