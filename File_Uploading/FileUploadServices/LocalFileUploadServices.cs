using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace File_Uploading.FileUploadServices
{
    public class LocalFileUploadServices : IFileUploadServices
    {
        private readonly IWebHostEnvironment environment;

        public LocalFileUploadServices(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(environment.WebRootPath, "images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }

            return "/images/" + fileName;
        }
    }
}
