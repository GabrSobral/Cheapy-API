using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Services
{
    public class ProccessUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;  
        public ProccessUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
            string uniqueFileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            string FilePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}