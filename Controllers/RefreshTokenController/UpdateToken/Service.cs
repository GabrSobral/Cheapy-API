using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Cheapy_API.Controllers.RefreshTokenController.UpdateToken
{
    public class Service
    {
        private readonly JsonWebToken _jsonWebToken;

        public Service(JsonWebToken jsonWebToken) => _jsonWebToken = jsonWebToken;

        public async Task<Object> Execute(
            AppDbContext context, 
            Guid refreshTokenId,
            Guid userId)
        {
            var refreshToken = await context.RefreshToken
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == refreshTokenId);

            if(refreshToken == null || refreshToken.UserId != userId)
                throw new Exception("Refresh Token Invalid status:400");

            var newToken = _jsonWebToken.Generate(refreshToken.Id);

            if(DateTime.Compare(refreshToken.ExpiresIn, DateTime.Now) < 0)
            {
                context.Remove(refreshToken);
                await context.SaveChangesAsync();
                throw new Exception("Refresh token expired, generate another status:400");
            }

            return new { token = newToken };
        }
    }
}