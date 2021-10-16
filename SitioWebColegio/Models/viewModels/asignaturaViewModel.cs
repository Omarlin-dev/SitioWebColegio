using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class asignaturaViewModel
    {
        public int idAsignatura { get; set; }
        public string nombre { get; set; }
        public int idProfesor { get; set; }
    }
}