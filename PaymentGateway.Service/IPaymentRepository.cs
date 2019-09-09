using System;
using System.Threading.Tasks;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service
{
    /// <summary>
    /// Definition of the payment repository
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Gets a payment
        /// </summary>
        /// <param name="id">id of the payment to get</param>
        /// <returns>the payment</returns>
        Task<Payment> Get(Guid id);

        /// <summary>
        /// Saves a payment
        /// </summary>
        /// <param name="payment">the payment to be saved</param>
        /// <returns>id of the saved payment</returns>
        Task<Guid> Save(Payment payment);
    }
}