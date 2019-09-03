using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/paymentHistory")]
    [ApiController]
    public class PaymentHistoryController : ControllerBase
    {
        [HttpGet("{guid}")]
        public async Task<Guid> Get(Guid guid)
        {
            return guid;
        }
    }
}