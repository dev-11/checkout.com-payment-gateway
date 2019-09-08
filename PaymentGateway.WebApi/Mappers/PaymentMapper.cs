using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentMapper : IMapper<Payment, PaymentDto>
    {
        private readonly IMapper<Card, CardDto> _cardMapper;

        public PaymentMapper(IMapper<Card, CardDto> cardMapper)
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
                Currency = obj.Currency,
                Card = _cardMapper.Map(obj.Card),
                IsSuccessful = obj.IsSuccessful,
                Id = obj.Id
            };
        }
    }
}