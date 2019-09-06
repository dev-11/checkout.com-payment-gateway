namespace PaymentGateway.Service
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom obj);
        TFrom Map(TTo obj);
    }
}