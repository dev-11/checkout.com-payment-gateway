using System;

namespace PaymentGateway.WebApi.Models
{
    /// <summary>
    /// Response of the payment
    /// </summary>
    public class PaymentResponseDto
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