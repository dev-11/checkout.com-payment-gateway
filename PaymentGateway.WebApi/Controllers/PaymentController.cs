using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        [HttpPost("{id}")]
        public async Task<int> Index(int id)
        {
            return id;
        }
    }
}