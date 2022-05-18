using AbsenceWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Helper
{
    public interface IFileWebHandler
    {
        string SaveFile(IFormFile IFormFile);
    }
}
