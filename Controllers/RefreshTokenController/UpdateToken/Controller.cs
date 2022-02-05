using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Controllers.RefreshTokenController.UpdateToken
{
    [ApiController]
    [Route("v1")]
    public class Controller : BaseController
    {
        private readonly JsonWebToken _jsonWebToken;
        public Controller(JsonWebToken jsonWebToken) => _jsonWebToken = jsonWebToken;

        [HttpPost("refresh-token/{refreshTokenId}")]
        public async Task<IActionResult> Handle(
            [FromServices] AppDbContext context,
            [FromRoute] Guid refreshTokenId,
            [FromBody] RequestModel model)
        {
            try
            {
                var result = await new Service(_jsonWebToken).Execute(
                    context, 
                    refreshTokenId,
                    model.UserId
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