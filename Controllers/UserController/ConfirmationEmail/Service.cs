using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Cheapy_API.Controllers.UserController.ConfirmationEmail
{
    public class Service
    {        
        public async Task<object> Execute(
            AppDbContext context, 
            RequestModel model,
            IConfiguration configuration )
        {
            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == model.Email.ToLower());

            if(user != null)
                throw new Exception("Email already registred, try another status:400");

            var token = new {
                Email = model.Email.ToLower(),
                ExpiresIn = DateTime.UtcNow.AddMinutes(40)
            };
            Console.WriteLine(JsonConvert.SerializeObject(token));

            var tokenEncrypted = Crypt.Encrypt(
                JsonConvert.SerializeObject(token).ToString(), 
                model.Email.ToLower()
            );

            string htmlBody = new StreamReader("Services/confirmation.html").ReadToEnd();
            htmlBody = htmlBody.Replace("${username}", model.Name);
            htmlBody = htmlBody.Replace("${email}", model.Email.ToLower());
            htmlBody = htmlBody.Replace("${token}", tokenEncrypted);

            new SendMail(configuration).Send(
                to: model.Email,
                subject: "Cheapy - Confirmação de e-mail",
                htmlBody: htmlBody
            );

            return new { token = tokenEncrypted };
        }
    }
}