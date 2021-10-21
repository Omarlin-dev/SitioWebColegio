﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Models.viewModels
{
    public class asignaturaViewModel 
    {
        public int idAsignatura { get; set; }
        [Required]
        public string nombre { get; set; }
        public int idProfesor { get; set; }
        public Nullable<int> idAlumno { get; set; }
    }
}