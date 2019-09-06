using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Service;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IMapper<PaymentRequest, PaymentRequestDto> _requestMapper;
        private readonly IMapper<PaymentResponse, PaymentResponseDto> _responseMapper;
        private readonly IPaymentService _paymentService;

        public PaymentController(IMapper<PaymentRequest,PaymentRequestDto> requestMapper,
                                 IMapper<PaymentResponse, PaymentResponseDto> responseMapper,
                                 IPaymentService paymentService)
        {
            _requestMapper = requestMapper;
            _paymentService = paymentService;
            _responseMapper = responseMapper;
        }

        [HttpPost]
        public IActionResult RequestPayment(PaymentRequestDto paymentRequest)
        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(paymentRequest);
//            }

            var serviceRequest = _requestMapper.Map(paymentRequest);
            var serviceResponse = _paymentService.ProcessPayment(serviceRequest);

            return Ok(_responseMapper.Map(serviceResponse));
        }
    }
}