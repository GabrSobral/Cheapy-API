using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using Cheapy_API.Data;
using Bcrypt = BCrypt.Net.BCrypt;
using Cheapy_API.Services;
using Newtonsoft.Json;

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
                .FirstOrDefaultAsync(x => (x.CPF == model.CPF) || (x.Email == model.Email.ToLower()));

            if(alreadyExists != null)
                throw new Exception("User already exists status:400");

            TokenDescrypted tokenData;
            try
            {
                tokenData = JsonConvert.DeserializeObject<TokenDescrypted>(
                    Crypt.Decrypt(model.Token));
            } 
            catch
            {
                throw new Exception("Token error status:400");
            }

            if(tokenData.Email != model.Email.ToLower())
                throw new Exception("Invalid Email status:400");

            if(DateTime.Compare(tokenData.ExpiresIn, DateTime.Now) < 0)
                throw new Exception("Token expired");

            var hashedPassword = Bcrypt.HashPassword(model.Password);

            User newUser = new User
            {
                CPF = model.CPF,
                Name = model.Name,
                Email = model.Email.ToLower(),
                Password = hashedPassword,
                City = model.City,
                Country = model.Country,
                State = model.State,
                PostalCode = model.PostalCode
            };

            await context.AddAsync(newUser);
            await context.SaveChangesAsync();

            var token = _jsonWebToken.Generate(newUser.Id);
            var refreshToken = await new HandleRefreshToken().Generate(context, newUser.Id);

            return new ResponseModel(newUser, token, refreshToken);
        }
    }
}