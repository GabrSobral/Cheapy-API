using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cheapy_API.Controllers.UserController.ConfirmationEmail
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        private readonly IConfiguration _configuration;

        public Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("users/confirmation")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromBody] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await new Service().Execute(context, model, _configuration);
                return Ok(result);
            } 
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}