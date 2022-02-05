using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Data;

namespace Cheapy_API.Controllers.UserController.Show
{
    public class Service
    {
        public async Task<dynamic> Execute(
            AppDbContext context, 
            Guid userId,
            string isSoft)
        {
            dynamic user;

            if(isSoft == "true")
                user = await context.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new UserSoft{ Name= x.Name, Photo = x.Photo })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            else 
                user = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == userId);

            if(user == null)
                throw new Exception("User not found status:400");

            if(user.Photo != null)
                user.Photo = $"https://localhost:5001/Uploads/{user.Photo}";            

            return user;
        }
    }
}