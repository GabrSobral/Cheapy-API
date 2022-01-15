using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Cheapy_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.UserController.UpdateData
{
    public class Service
    {
        public async Task<User> Execute(
            AppDbContext context, 
            RequestModel model, 
            string userEmail,
            IWebHostEnvironment webHostEnviroment )
        {   
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userEmail);

            if(user == null)
                throw new Exception("User not found status:400");

            ProccessUpload handleFiles = new ProccessUpload(webHostEnviroment);

            if(model.Name != "")
                user.Name = model.Name;

            if(model.Photo != null)
            {   
                if(user.Photo != null)
                    handleFiles.DeleteFile(user.Photo);
                    
                user.Photo = handleFiles.Upload(model.Photo);;
            }

            context.Users.Update(user);
            await context.SaveChangesAsync();

            return user;
        }
    }
}