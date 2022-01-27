using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Controllers.FavoriteController.Mark
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpPost("favorite/{productId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid productId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await new Service().Execute(
                    context,
                    GetUserId(),
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