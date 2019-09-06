using Moq;

namespace PaymentGateway.Service.Clients
{
    public class BankClientMock
    {
        public IBankClient Mock()
        {
            var mock = new Mock<IBankClient>();
            mock.Setup(x => x.ProcessTransaction(It.IsAny<BankTransactionRequestDto>()))
                .Returns((BankTransactionRequestDto request) =>
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
                    };
                });

            return mock.Object;
        }
    }
}