namespace PaymentGateway.WebApi.Models
{
    /// <summary>
    /// The payment request
    /// </summary>
    public class PaymentRequestDto
    {
        /// <summary>
        /// The card of the request
        /// </summary>
        public CardDto Card { get; set; }

        /// <summary>
        /// The amount of the request
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// The currency of the request
        /// </summary>
        public string Currency { get; set; }
    }
}