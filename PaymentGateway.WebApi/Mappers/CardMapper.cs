using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class CardMapper : IMapper<CardDto, Card>, IMapper<Card, CardDto>
    {
        public Card Map(CardDto obj)
        {
            return obj is null
                ? Card.Empty
                : new Card
                {
                    Cvv = obj.Cvv,
                    CardNumber = obj.CardNumber,
                    ExpiryYear = obj.ExpiryYear,
                    ExpiryMonth = obj.ExpiryMonth
                };
        }

        public CardDto Map(Card obj)
        {
            return obj is null
                ? CardDto.Empty
                : new CardDto
                {
                    Cvv = obj.Cvv,
                    CardNumber = obj.CardNumber,
                    ExpiryMonth = obj.ExpiryMonth,
                    ExpiryYear = obj.ExpiryYear
                };
        }
    }
}