namespace PaymentGateway.WebApi.Mappers
{
    /// <summary>
    /// Definition to map an object to an other
    /// </summary>
    /// <typeparam name="TFrom">The source type</typeparam>
    /// <typeparam name="TTo">The target type</typeparam>
    public interface IMapper<in TFrom, out TTo>
    {
        /// <summary>
        /// Maps from TFrom to TTo
        /// </summary>
        /// <param name="obj">The source object</param>
        /// <returns>The mapped object</returns>
        TTo Map(TFrom obj);
    }
}
