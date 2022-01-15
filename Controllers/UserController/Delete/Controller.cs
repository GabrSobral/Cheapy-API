using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Data;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.UserController.Delete
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] string userId )
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);

                if(user == null)
                    return BadRequest("User not found");

                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception error)
            {
                return new ErrorCatcher(error).Return();
            }
        }
    }
}