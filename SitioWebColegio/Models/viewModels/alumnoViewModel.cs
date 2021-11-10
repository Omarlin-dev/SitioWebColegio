using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class alumnoViewModel
    {
        public alumnoViewModel()
        {
            nombreAsignatura = new List<string>();
        }
       public virtual Alumno alumno { get; set; }

        public List<Asignatura> asignaturas { get; set; }

        public virtual Asignatura asignatura { get; set; }
        public List<string> nombreAsignatura { get; set; }

    }
}