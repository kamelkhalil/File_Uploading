using File_Uploading.FileUploadServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Uploading.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileUploadServices fileUploadService;
        public string filePath;

        public IndexModel(ILogger<IndexModel> logger, IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            this.fileUploadService = fileUploadServices;
        }

        public void OnGet()
        {

        }

        public async Task OnPost(IFormFile file)
        {
            if (file != null)
            {
                filePath = await fileUploadService.UploadFileAsync(file);
            }
        }
    }
}
