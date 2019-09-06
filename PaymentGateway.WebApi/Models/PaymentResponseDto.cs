using System;

namespace PaymentGateway.WebApi.Models
{
    public class PaymentResponseDto
    {
        public bool IsRequestSucceeded { get; set; }
        public Guid PaymentId { get; set; }
    }
}