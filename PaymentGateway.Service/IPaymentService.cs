using System;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service
{
    /// <summary>
    /// Definition how to handle payments, payment requests
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Processes a payment request
        /// </summary>
        /// <param name="paymentRequest">the request</param>
        /// <returns>response of the process</returns>
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);

        /// <summary>
        /// Gets a payment
        /// </summary>
        /// <param name="paymentId">Id of the payment</param>
        /// <returns>the payment of the id</returns>
        Payment GetPayment(Guid paymentId);

    }
}