using AbsenceWebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.ViewModels
{
    public class AbsenceInputsViewModel
    {
        [Required]
        public IFormFile FileA { get; set; }

        [Required]
        public IFormFile FileB { get; set; }

        [Required]
        public IFormFile StartData { get; set; }

    }
}
