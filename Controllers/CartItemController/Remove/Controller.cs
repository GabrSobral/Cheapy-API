using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.CartItemController.Remove
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpDelete("shopping/{productId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid productId )
        {
            try
            {
                await new Service().Execute(
                    context, 
                    await GetUserId(context),
                    productId
                );
                return Ok();
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}