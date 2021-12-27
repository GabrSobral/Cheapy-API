using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.ShoppingCartsController.MyList
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpGet("shopping/my-list")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context)
        {
            try
            {
                var result = await new Service().Execute(context, GetUserId());
                return Created("", result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}