using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Models;

namespace Cheapy_API.Services
{
    public class HandleRefreshToken
    {
        public async Task<RefreshToken> Generate(AppDbContext context, Guid userId)
        {
            var currentDate = DateTime.Now;
            var expiresIn = currentDate.AddDays(4);

            var refreshToken = new RefreshToken
            {
                ExpiresIn = expiresIn,
                UserId = userId
            };

            await context.RefreshToken.AddAsync(refreshToken);
            await context.SaveChangesAsync();
            
            return refreshToken;
        }
    }
}