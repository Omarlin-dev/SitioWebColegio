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
    
    public partial class Administrador
    {
        public int idAdmin { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreusuario { get; set; }
        public string clave { get; set; }
        public Nullable<int> idRol { get; set; }
    
        public virtual Rol_Operacion Rol_Operacion { get; set; }
    }
}
