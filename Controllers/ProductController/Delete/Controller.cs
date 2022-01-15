using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Controllers.ProductController.Delete
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
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            try
            {
                await new Service().Execute(context, id, userEmail: GetUserEmail(), _webHostEnvironment);
                return Ok();
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}