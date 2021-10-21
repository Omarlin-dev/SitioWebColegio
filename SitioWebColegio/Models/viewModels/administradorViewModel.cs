using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class administradorViewModel
    {
        public int idAdmin { get; set; }
        [Required]
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Required]
        public string nombreusuario { get; set; }
        [Required]
        public string clave { get; set; }
        public Nullable<int> idRol { get; set; }

    }
}