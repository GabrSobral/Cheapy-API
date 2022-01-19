using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.UserController.Show
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpGet("users/show")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromQuery] string isSoft)
        {
            try
            {
                var result = await new Service().Execute(context, GetUserId(), isSoft);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}