using AbsenceWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Helper
{
    public class FileWebHandler: IFileWebHandler
    {                        
        
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileWebHandler(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        public string SaveFile(IFormFile IFormFile)
        {
            string UploadsFile = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
            var FileName = Guid.NewGuid().ToString() + "_" + IFormFile.FileName;
            var FilePath = Path.Combine(UploadsFile, FileName);
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                IFormFile.CopyTo(stream);
            }
            return FilePath;
        }
    
}
}
