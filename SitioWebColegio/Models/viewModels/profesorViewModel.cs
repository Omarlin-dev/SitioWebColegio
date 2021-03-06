using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class profesorViewModel 
    {
        public profesorViewModel()
        {
            nombreAsignatura = new List<string>();
        }

        public int idProfesor { get; set; }
        [Required]
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Required]
        public string nombreUsuario { get; set; }
        [Required]
        public string clave { get; set; }
        [Required]
        public string especialidad { get; set; }
        public Nullable<int> idRol { get; set; }

        // public virtual Asignatura AsignaturaModel { get; set; }
        public List<Asignatura> asiginaturas { get; set; }
        public List<string> nombreAsignatura { get; set; } 

        public Asignatura asignatura { get; set; }
    }
}