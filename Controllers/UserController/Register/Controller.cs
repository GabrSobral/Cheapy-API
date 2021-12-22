using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cheapy_API.Data;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.UserController.Register
{
    [ApiController]
    [Route("v1")]
    public class Controller : ControllerBase
    {
        [HttpPost("users")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromBody] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new { error = "Invalid model" });

            try
            {
                var result  = await new Service().Execute(context, model);
                return Created("", result);
            } 
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}