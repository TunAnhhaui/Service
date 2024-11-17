using api.Dto;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;

        public PaymentController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }
        [HttpPost("create-url")]
        public IActionResult CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(url);
        }
        [HttpGet("callback")]
        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (!response.Success)
            {
                return Redirect($"http://localhost:8080/checkout?orderId={response.OrderId}&&Status=payment-failure");
            }
            return Redirect($"http://localhost:8080/checkout?orderId={response.OrderId}&&Status=payment-success");
        }
    }
}
