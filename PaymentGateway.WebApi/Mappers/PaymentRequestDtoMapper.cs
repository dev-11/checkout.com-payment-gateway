using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentRequestDtoMapper : IMapper<PaymentRequestDto, PaymentRequest>
    {
        private readonly IMapper<CardDto, Card> _cardMapper;
        public PaymentRequestDtoMapper(IMapper<CardDto, Card> cardMapper)
        {
            _cardMapper = cardMapper;
        }

        public PaymentRequest Map(PaymentRequestDto obj)
        {
            if (obj is null)
            {
                return PaymentRequest.Empty;
            }

            return new PaymentRequest
            {
                Amount = obj.Amount,
                Currency = obj.Currency,
                Card = _cardMapper.Map(obj.Card)
            };
        }
    }
}
