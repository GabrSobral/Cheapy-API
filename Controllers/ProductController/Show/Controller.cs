using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.ProductController.Show
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [HttpGet("products/{productId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid productId)
        {
            try
            {
                var result = await new Service().Execute(context, productId);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}