using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitioWebColegio.Models.viewModels;

namespace SitioWebColegio.Models.viewModels
{
    public class AlumnoProfesorAsignaturaViewModel 
    {
        public List<profesorViewModel> profesorList { get; set; } 
        public List<Alumno> alumnoList { get; set; }
        public List<Alumno> alumnoListdb { get; set; }

        public List<asignaturaViewModel> asignaturaList { get; set; }

        public asignaturaViewModel AsignaturaFirst { get; set; }
        public virtual Alumno alumno { get; set; } 

    }
}