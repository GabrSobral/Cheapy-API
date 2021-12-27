using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cheapy_API.Controllers.FeedbackController.List
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [Authorize]
        [HttpGet("feedbacks/{id}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            try
            {
                var result = await new Service().Execute(context, id);
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}