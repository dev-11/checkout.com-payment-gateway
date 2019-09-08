using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Mappers
{
    public class PaymentResponseMapper : IMapper<PaymentResponse, PaymentResponseDto>
    {
        public PaymentResponseDto Map(PaymentResponse obj)
        {
            if (obj is null)
            {
                return new PaymentResponseDto();
            }

            return new PaymentResponseDto
            {
                PaymentId = obj.PaymentId,
                IsRequestSucceeded = obj.IsRequestSucceeded
            };
        }
    }
}
