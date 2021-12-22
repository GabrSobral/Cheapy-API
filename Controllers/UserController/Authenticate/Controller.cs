using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.UserController.Authenticate
{
    [ApiController]
    [Route("v1")]
    public class Controller : ControllerBase
    {
        [HttpPost("users/authenticate")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromBody] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Invalid model");

            try
            {
                var result = await new Service().Execute(context, model);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}