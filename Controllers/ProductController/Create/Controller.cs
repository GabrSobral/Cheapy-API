using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Controllers.ProductController.Create
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Controller(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpPost("products")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromForm] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await new Service().Execute(
                    context, model, GetUserId(), _webHostEnvironment);
                return Created("", result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}