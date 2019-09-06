namespace PaymentGateway.Service.Clients
{
    public class BankClientMock : IBankClient
    {
        public BankTransactionResponseDto ProcessTransaction(BankTransactionRequestDto request)
        {
            if (request is null)
            {
                return new BankTransactionResponseDto
                {
                    IsTransactionSuccessful = false
                };
            }

            return new BankTransactionResponseDto
            {
                IsTransactionSuccessful = request.Amount <= 100
            };        }
    }
}