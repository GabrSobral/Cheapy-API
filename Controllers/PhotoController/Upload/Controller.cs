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
            Console.Write("webHostEnvironment Controller: ");
            Console.WriteLine(webHostEnvironment.WebRootPath);
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpPost("photos/new/{productId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromForm] RequestModel model,
            [FromRoute] Guid productId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {   
                var result = await new Service().Execute(
                    context, model, _webHostEnvironment, productId);
                    
                return Created("", result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
        
    }
}