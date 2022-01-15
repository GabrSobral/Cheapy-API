using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.UserController.UpdateData
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        public Controller(IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
        }

        [Authorize]
        [HttpPatch("users")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromForm] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await new Service().Execute(
                    context, model, GetUserEmail(), _webHostEnviroment);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}