using System;

namespace PaymentGateway.Service.Dom
{
    /// <summary>
    /// Response of the payment
    /// </summary>
    public class PaymentResponse
    {
        /// <summary>
        /// The result of the request
        /// </summary>
        public bool IsRequestSucceeded { get; set; }

        /// <summary>
        /// The id of the processed payment
        /// </summary>
        public Guid PaymentId { get; set; }
    }
}