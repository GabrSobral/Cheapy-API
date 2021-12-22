using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Cheapy_API.Controllers.UserController.Authenticate
{
    public class Service
    {
        public async Task<User> Execute(AppDbContext context, RequestModel model)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email.ToLower());

            if(user == null)
                throw new Exception("Email/Password invalid status:400");

            if(!Bcrypt.Verify(model.Password, user.Password))
                throw new Exception("Email/Password invalid status:400");

            return user;
        }
    }
}