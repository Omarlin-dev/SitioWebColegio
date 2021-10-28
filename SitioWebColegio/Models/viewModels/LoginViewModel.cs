using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Usuario")]
        public string NameUser { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public string Rol { get; set; } 
    }
}