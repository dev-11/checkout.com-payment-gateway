using System.Threading.Tasks;

namespace PaymentGateway.Service.Clients
{
    /// <summary>
    /// Interface to communicate with the Acquiring Bank
    /// </summary>
    public interface IBankClient
    {
        /// <summary>
        /// Sends a request to the bank to process the ongoing transaction
        /// </summary>
        /// <param name="request">the request to be processed</param>
        /// <returns>response of the bank</returns>
        Task<BankTransactionResponseDto> ProcessTransaction(BankTransactionRequestDto request);
    }
}