using System;

namespace PaymentGateway.Service.Dom
{
    public class PaymentResponse
    {
        public bool IsRequestSucceeded { get; set; }
        public Guid PaymentId { get; set; }
    }
}