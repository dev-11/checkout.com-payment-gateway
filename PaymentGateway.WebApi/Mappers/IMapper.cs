namespace PaymentGateway.WebApi.Mappers
{
    public interface IMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom obj);
    }
}
