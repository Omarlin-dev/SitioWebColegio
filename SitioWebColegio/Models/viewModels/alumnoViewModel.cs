using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class alumnoViewModel
    {
        public int idAlumno { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<int> idRol { get; set; }
    }
}