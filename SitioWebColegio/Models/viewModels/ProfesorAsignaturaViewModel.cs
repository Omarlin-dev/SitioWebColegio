using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class ProfesorAsignaturaViewModel
    {
        public List<asignaturaViewModel> asiginaturas { get; set; }
        public Asignatura asiginatura { get; set; }

        public List<string> nombreAsignatura { get; set; }

        public ProfesorOnlyViewModel profesorone { get; set; }
    }
}