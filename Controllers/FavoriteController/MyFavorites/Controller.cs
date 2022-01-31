using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Controllers.FavoriteController.MyFavorites
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpGet("favorite/my-list")]
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