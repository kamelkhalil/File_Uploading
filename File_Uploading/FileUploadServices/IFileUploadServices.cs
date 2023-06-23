using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace File_Uploading.FileUploadServices
{
    public interface IFileUploadServices
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}

