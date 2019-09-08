namespace PaymentGateway.Service.Clients
{
    public interface IBankClient
    {
        BankTransactionResponseDto ProcessTransaction(BankTransactionRequestDto request);
    }
}