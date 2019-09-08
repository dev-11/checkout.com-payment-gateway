using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentRequestMapper : IMapper<PaymentRequestDto, PaymentRequest>
    {
        private readonly IMapper<CardDto, Card> _cardMapper;
        public PaymentRequestMapper(IMapper<CardDto, Card> cardMapper)
        {
            _cardMapper = cardMapper;
        }

        public PaymentRequest Map(PaymentRequestDto obj)
        {
            if (obj is null)
            {
                return new PaymentRequest();
            }

            return new PaymentRequest
            {
                Amount = obj.Amount,
                Card = _cardMapper.Map(obj.Card)
            };
        }
    }
}
