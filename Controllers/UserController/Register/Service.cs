using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Bcrypt = BCrypt.Net.BCrypt;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.UserController.Register
{
    public class Service
    {
        private JsonWebToken _jsonWebToken;

		public Service(JsonWebToken jsonWebToken) => _jsonWebToken = jsonWebToken;
        
        public async Task<ResponseModel> Execute(AppDbContext context, RequestModel model)
        {
            var alreadyExists = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == model.Email.ToLower());

            if(alreadyExists != null)
                throw new Exception("User already exists status:400");

            var hashedPassword = Bcrypt.HashPassword(model.Password);

            User newUser = new User
            {
                Name = model.Name,
                Email = model.Email.ToLower(),
                Password = hashedPassword,
                Role = model.Role
            } ;

            await context.AddAsync(newUser);
            await context.SaveChangesAsync();

            var token = _jsonWebToken.Generate(newUser);

            return new ResponseModel(newUser, token);
        }
    }
}