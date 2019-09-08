using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service.Mappers
{
    /// <summary>
    /// Interface to build a payment
    /// </summary>
    public interface IPaymentMapper
    {
        /// <summary>
        /// Maps the parameters into a Payment
        /// </summary>
        /// <param name="id">the id</param>
        /// <param name="isSuccessful">is successful flag</param>
        /// <param name="paymentRequest">the payment request</param>
        /// <returns>the payment</returns>
        Payment Map(Guid id, bool isSuccessful, PaymentRequest paymentRequest);
    }
}