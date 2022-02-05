using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Controllers.PaymentGatewayController.Checkout
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpPost("payment/checkout")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromBody] List<RequestModel> model)
        {
            try
            {
                var result = await new Service().Execute(
                    context, 
                    GetUserId(),
                    model
                );
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}