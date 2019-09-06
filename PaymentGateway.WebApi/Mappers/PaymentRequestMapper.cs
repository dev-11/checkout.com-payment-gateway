using PaymentGateway.Service;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentRequestMapper : IMapper<PaymentRequest, PaymentRequestDto>
    {
        public PaymentRequestDto Map(PaymentRequest obj)
        {
            if (obj is null)
            {
                return new PaymentRequestDto();
            }

            return new PaymentRequestDto
            {
                Amount = obj.Amount,
                Card = new CardDto
                {
                    Cvv = obj.Card.Cvv,
                    CardNumber = obj.Card.CardNumber,
                    ExpiryYear = obj.Card.ExpiryYear,
                    ExpiryMonth = obj.Card.ExpiryMonth
                }
            };
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
                Card = new Card
                {
                    Cvv = obj.Card.Cvv,
                    CardNumber = obj.Card.CardNumber,
                    ExpiryYear = obj.Card.ExpiryYear,
                    ExpiryMonth = obj.Card.ExpiryMonth
                }
            };
        }
    }
}