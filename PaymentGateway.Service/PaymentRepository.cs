using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<Payment> Get(Guid id)
        {
            return await Task.Run(() => _storage.ContainsKey(id) ? _storage[id] : Payment.Empty);
        }

        public async Task<Guid> Save(Payment payment)
        {
            return await Task.Run(() =>
            {
                var id = Guid.NewGuid();
                payment.Id = id;
                _storage[id] = payment;

                return id;
            });
        }
    }
}