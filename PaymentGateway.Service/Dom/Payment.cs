using System;

namespace PaymentGateway.Service.Dom
{
    /// <summary>
    /// The currency of the request
    /// </summary>
    public class Payment : PaymentRequest
    {
        /// <summary>
        /// The result of the payment
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// The id of the payment
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Empty object for null object pattern
        /// </summary>
        public new static Payment Empty => new Payment
        {
            Card = Card.Empty
        };
    }
}