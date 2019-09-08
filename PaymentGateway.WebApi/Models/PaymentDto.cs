using System;

namespace PaymentGateway.WebApi.Models
{
    /// <summary>
    /// The processed payment
    /// </summary>
    public class PaymentDto : PaymentRequestDto
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
        public static PaymentDto Empty => new PaymentDto();
    }
}