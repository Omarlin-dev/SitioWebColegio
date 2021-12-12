using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Models;

namespace SitioWebColegio.Filtro
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autorizados : AuthorizeAttribute
    {
        private Administrador admin;

        private Profesor profesor;

        private Alumno alumno;

        private DBColegioEntities db = new DBColegioEntities();

        private int idOperacionadmin, idOperacionProfesor, idOperacionAlumno;

        public Autorizados(int idOperacionadmin)
        {
            this.idOperacionadmin = idOperacionadmin;
        }
        public Autorizados(int idOperacionadmin, int idOperacionProfesor, int idOperacionAlumno)
        {
            this.idOperacionadmin = idOperacionadmin;
            this.idOperacionProfesor = idOperacionProfesor;
            this.idOperacionAlumno = idOperacionAlumno;
        }

        public Autorizados(int idOperacionAlumno, int Id) 
        {
            this.idOperacionAlumno = idOperacionAlumno;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                admin = (Administrador)HttpContext.Current.Session["Administrador"];

                profesor = (Profesor)HttpContext.Current.Session["Profesor"];

                alumno = (Alumno)HttpContext.Current.Session["Alumno"];

                IQueryable<Rol_Operacion> miOperacionAdmin=null;
                IQueryable<Rol_Operacion> miOperacionAlumno=null;
                IQueryable<Rol_Operacion> miOperacionProfesor=null;


                if (admin != null)
                {
                   miOperacionAdmin = from d in db.Rol_Operacion
                                       where d.idRol == admin.idRol
                                       && d.idOperacion == idOperacionadmin
                                       select d;

                    if (miOperacionAdmin.ToList().Count() < 1 )
                    {
                        filterContext.Result = new RedirectResult("~/Error/NoAutorizado");
                    }
                }
                    
                if(profesor != null)
                {
                   miOperacionProfesor = from d in db.Rol_Operacion
                                          where d.idRol == profesor.idRol
                                          && d.idOperacion == idOperacionProfesor
                                          select d;

                    if (miOperacionProfesor.ToList().Count() < 1 )
                    {
                       filterContext.Result = new RedirectResult("~/Error/NoAutorizado");
                    }
                }

                if (alumno != null)
                {
                    miOperacionAlumno = from d in db.Rol_Operacion
                                        where d.idRol == alumno.idRol
                                        && d.idOperacion == idOperacionAlumno
                                        select d;

                    if (miOperacionAlumno.ToList().Count() < 1)
                    {
                        filterContext.Result = new RedirectResult("~/Error/NoAutorizado");
                    }

                 }
                if (miOperacionAlumno == null && miOperacionProfesor == null && miOperacionAdmin == null)
                {
                   filterContext.Result = new RedirectResult("~/Error/NoAutorizado");

                }

            }
            catch (Exception)
            {
              filterContext.Result = new RedirectResult("~/Error/NoAutorizado");
            }
        }
    }
}