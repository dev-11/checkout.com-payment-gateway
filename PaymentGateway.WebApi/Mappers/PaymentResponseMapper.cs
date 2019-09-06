using PaymentGateway.Service;
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

        public PaymentResponse Map(PaymentResponseDto obj)
        {
            if (obj is null)
            {
                return new PaymentResponse();
            }

            return new PaymentResponse
            {
                PaymentId = obj.PaymentId,
                IsRequestSucceeded = obj.IsRequestSucceeded
            };
        }
    }
}