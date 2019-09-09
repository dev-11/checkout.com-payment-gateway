using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Service;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IMapper<PaymentRequestDto, PaymentRequest> _requestMapper;
        private readonly IMapper<PaymentResponse, PaymentResponseDto> _responseMapper;
        private readonly IMapper<Payment, PaymentDto> _paymentDtoMapper;
        private readonly IPaymentService _paymentService;

        public PaymentController(IMapper<PaymentRequestDto,PaymentRequest> requestMapper,
                                 IMapper<PaymentResponse, PaymentResponseDto> responseMapper,
                                 IMapper<Payment, PaymentDto> paymentDtoMapper,
                                 IPaymentService paymentService)
        {
            _requestMapper = requestMapper;
            _paymentService = paymentService;
            _responseMapper = responseMapper;
            _paymentDtoMapper = paymentDtoMapper;
        }

        [HttpPost("processPayment")]
        public async Task<IActionResult> RequestPayment([FromBody] PaymentRequestDto paymentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(paymentRequest);
            }

            var serviceRequest = _requestMapper.Map(paymentRequest);
            var serviceResponse = await _paymentService.ProcessPayment(serviceRequest);

            return Ok(_responseMapper.Map(serviceResponse));
        }

        [HttpGet("getPayment")]
        public async Task<IActionResult> GetPayment(Guid paymentId)
        {
            if (paymentId == Guid.Empty)
            {
                return BadRequest("'paymentId' can't be empty.");
            }

            var result = await _paymentService.GetPayment(paymentId);
            
            return Ok(_paymentDtoMapper.Map(result));
        }
    }
}