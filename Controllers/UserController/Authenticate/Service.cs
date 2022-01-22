using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Bcrypt = BCrypt.Net.BCrypt;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.UserController.Authenticate
{
    public class Service
    {
        private JsonWebToken _jsonWebToken;

		public Service(JsonWebToken jsonWebToken) => _jsonWebToken = jsonWebToken;

        public async Task<ResponseModel> Execute(AppDbContext context, RequestModel model)
        {
            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == model.Email.ToLower());

            if(user == null)
                throw new Exception("Email/Password invalid status:400");

            if(!Bcrypt.Verify(model.Password, user.Password))
                throw new Exception("Email/Password invalid status:400");

            var token = _jsonWebToken.Generate(user);
            user.Photo = $"https://localhost:5001/Uploads/{user.Photo}";            

            return new ResponseModel(user, token);
        }
    }
}