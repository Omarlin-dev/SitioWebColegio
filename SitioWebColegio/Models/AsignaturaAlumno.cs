//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitioWebColegio.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AsignaturaAlumno
    {
        public int Id { get; set; }
        [Required]
        public int idAlumno { get; set; }
        [Required]
        public int idAsignatura { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Asignatura Asignatura { get; set; }
    }
}
