using System;

namespace PaymentGateway.WebApi.Models
{
    public class PaymentDto : PaymentRequestDto
    {
        public bool IsSuccessful { get; set; }
        public Guid Id { get; set; }

        public static PaymentDto Empty => new PaymentDto();
    }
}