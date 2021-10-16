using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class administradorViewModel
    {
        public int idAdmin { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreusuario { get; set; }
        public string clave { get; set; }
        public Nullable<int> idRol { get; set; }

    }
}