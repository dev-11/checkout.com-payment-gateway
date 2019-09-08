using System;
using System.Collections.Generic;
using PaymentGateway.Service.Dom;

namespace PaymentGateway.Service
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDictionary<Guid, Payment> _storage;

        public PaymentRepository()
        {
            _storage = new Dictionary<Guid, Payment>();
        }
        
        public Payment Get(Guid id)
        {
            return _storage.ContainsKey(id) ? _storage[id] : Payment.Empty;
        }

        public Guid Save(Payment payment)
        {
            var id = Guid.NewGuid();
            payment.Id = id;
            _storage[id] = payment;

            return id;
        }
    }
}