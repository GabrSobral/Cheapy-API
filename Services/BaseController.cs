using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cheapy_API.Data;

namespace Cheapy_API.Services
{
    public class BaseController : ControllerBase
    {
        protected string GetUserEmail()
        {
            return User.Claims.First(i => i.Type == "Email").Value;
        }

        protected async Task<string> GetUserId(AppDbContext context)
        {
            return await context.Users
                .Where(x => x.Email == GetUserEmail())
                .Select(x => x.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}