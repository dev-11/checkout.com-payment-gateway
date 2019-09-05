using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        [HttpPost]
        public async Task<int> RequestPayment(int id)
        {
            return id;
        }
    }
}