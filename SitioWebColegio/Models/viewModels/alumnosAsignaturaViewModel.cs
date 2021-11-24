using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class alumnosAsignaturaViewModel
    {
        public int Id { get; set; }
        public int idAlumno { get; set; }
        public int idAsignatura { get; set; }
    }
}