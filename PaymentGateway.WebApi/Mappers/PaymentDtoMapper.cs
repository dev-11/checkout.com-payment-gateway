using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentDtoMapper : IMapper<Payment, PaymentDto>
    {
        private static IMapper<Card, CardDto> _cardMapper;

        public PaymentDtoMapper(IMapper<Card, CardDto> cardMapper)
        {
            _cardMapper = cardMapper;
        }

        public PaymentDto Map(Payment obj)
        {
            if (obj is null)
            {
                return PaymentDto.Empty;
            }

            return new PaymentDto
            {
                Amount = obj.Amount,
                Card = _cardMapper.Map(obj.Card),
                IsSuccessful = obj.IsSuccessful,
                Id = obj.Id
            };
        }
    }
}