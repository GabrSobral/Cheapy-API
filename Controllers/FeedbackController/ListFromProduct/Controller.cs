using System;
using Cheapy_API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.FeedbackController.ListFromProduct
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [HttpGet("feedbacks/{id}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id,
            [FromQuery] int page)
        {
            try
            {
                var result = await new Service().Execute(
                    context, 
                    id, 
                    page,
                    GetUserId()
                );
                return Ok(result);
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}