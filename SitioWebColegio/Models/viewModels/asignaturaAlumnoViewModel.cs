using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class asignaturaAlumnoViewModel
    {
        public AsignaturaAlumno oneAsignaturasAlumnos { get; set; }
        public AlumnosViewModels oneAlumnos { get; set; }
        public asignaturaViewModel oneAsignaturas { get; set; }
        public List<AlumnosViewModels> alumnos { get; set; }
        public List<asignaturaViewModel> asignaturas { get; set; }
        public AsignaturaAlumno alumnoAsignaturaGuardar { get; set; }
    }
}