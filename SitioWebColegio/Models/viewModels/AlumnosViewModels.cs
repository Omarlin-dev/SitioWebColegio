using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class AlumnosViewModels
    {
        public int idAlumno { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string nombreUsuario { get; set; }
    }
}