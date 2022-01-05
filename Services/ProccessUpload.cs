using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Cheapy_API.Services
{
    public class ProccessUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;  
        private readonly string UploadFolder;

        public ProccessUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            UploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        }

        public string Upload(IFormFile file)
        {
            string uniqueFileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            string FilePath = Path.Combine(UploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        public void DeleteFile(string fileName)
        {
            string FilePath = Path.Combine(UploadFolder, fileName);
            File.Delete(FilePath);
        }
    }
}