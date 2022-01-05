using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.ProductController.List
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [HttpGet("products")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context)
        {
            try
            {
                var result = await new Service().Execute(context);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}