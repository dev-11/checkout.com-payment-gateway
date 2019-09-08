using System;

namespace PaymentGateway.Service.Dom
{
    public class Payment : PaymentRequest
    {
        public bool IsSuccessful { get; set; }
        public Guid Id { get; set; }

        public new static Payment Empty => new Payment
        {
            Card = Card.Empty
        };
    }
}