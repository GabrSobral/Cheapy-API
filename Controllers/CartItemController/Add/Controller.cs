using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.ShoppingCartsController.Add
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpPost("shopping/add")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromBody] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await new Service().Execute(context, model, GetUserId());
                return Created("", result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}