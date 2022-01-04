using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Controllers.PhotoController.Upload
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
        [HttpPost("photos/new")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromForm] RequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {   
                var result = await new Service().Execute(context, model, _webHostEnvironment);
                return Created("", result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
        
    }
}