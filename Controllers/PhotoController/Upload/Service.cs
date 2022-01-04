using System;
using System.Threading.Tasks;
using Cheapy_API.Data;
using Microsoft.EntityFrameworkCore;
using Cheapy_API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Cheapy_API.Services;

namespace Cheapy_API.Controllers.PhotoController.Upload
{
    public class Service
    {
        public async Task<List<Photos>> Execute(
            AppDbContext context, 
            RequestModel model,
            IWebHostEnvironment webHostEnviroment)
        {
            string fileName = new ProccessUpload(webHostEnviroment).Upload(model.Photo);
            
            Console.WriteLine(model.Photo);
            Console.WriteLine(model.ProductId);

            return await context.Photos.ToListAsync();
        }
    }
}