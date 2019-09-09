using System.Threading.Tasks;

namespace PaymentGateway.Service.Clients
{
    public class BankClientMock : IBankClient
    {
        public async Task<BankTransactionResponseDto> ProcessTransaction(BankTransactionRequestDto request)
        {
            if (request is null)
            {
                return await Task.Run(() => new BankTransactionResponseDto
                {
                    IsTransactionSuccessful = false
                });
            }

            return await Task.Run(() => new BankTransactionResponseDto
            {
                IsTransactionSuccessful = request.Amount <= 100
            });
        }
    }
}