using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.ProductController.MyProducts
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [HttpGet("products/my")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context)
        {
            try
            {
                var result = await new Service().Execute(context, GetUserId());
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}