using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitioWebColegio.Models.viewModels;

namespace SitioWebColegio.Models.viewModels
{
    public class AlumnoProfesorAsignaturaViewModel 
    {
        public AlumnoProfesorAsignaturaViewModel()
        {
            nombreAsignatura = new List<string>();
        }

        public List<Profesor> profesorList { get; set; }
        public Profesor profesorFirts { get; set; }
               
        public List<Asignatura> asignaturaList { get; set; }

        public Asignatura AsignaturaFirst { get; set; }

        public List<string> nombreAsignatura { get; set; }

    }
}