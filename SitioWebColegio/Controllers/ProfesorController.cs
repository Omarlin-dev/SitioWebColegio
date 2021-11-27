using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;
using SitioWebColegio.Filtro;
using SitioWebColegio.Datos;

namespace SitioWebColegio.Controllers
{
    public class ProfesorController : Controller
    {
        private profesorDatos datosProfesor = new profesorDatos();
        private asignaturasDatos datosAsignatura = new asignaturasDatos();
        // GET: Profesores
        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 6, idOperacionAlumno: 11)]
        public ActionResult IndexProfesores()
        {
            return View();
        }        

        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 7, idOperacionAlumno: 12)]
        public ActionResult DetalleProfesor(int Id)
        {
            var profesor = datosProfesor.DetalleProfesor(Id);
            return View(profesor);
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult IndexAdmin()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarP"];

            return View();
        }

        public ActionResult GetDataProfesorTodos()
        {
            var lst = datosProfesor.GetDataProfesores();
            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Nuevo()
        {
            return View();
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Nuevo(profesorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            datosProfesor.Nuevo(model);
            return Redirect("IndexAdmin");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Editar(int Id)
        {
            var modelo = datosProfesor.ConsultarProfesor(Id);
            return View(modelo);
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Editar(profesorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            datosProfesor.Editar(model);

            return Redirect("IndexAdmin");

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Eliminar(int Id)
        {
           
            TempData["MensajeEliminarP"] = "Profesor/a Eliminado/a con exito";
            datosProfesor.Eliminar(Id);

            return Redirect("IndexAdmin");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Asignatura()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarA"];
            return View();
        }

        public ActionResult GetDataProfesoresAsignaturas()
        {
            var lst = datosAsignatura.GetAsignaturas();

            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaNuevo()
        {
            var modelo = datosAsignatura.ConsultarAsignatura();
             
            return View(modelo);
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaNuevo(AlumnoProfesorAsignaturaViewModel modelo)
        {

            if (!ModelState.IsValid)
                return View(modelo);

            datosAsignatura.AsignaturaNuevo(modelo);

            return Redirect("Asignatura");

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEditar(int Id)
        {
            var modelo = datosAsignatura.AsignaturaEditar(Id);

            return View(modelo);
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaEditar(AlumnoProfesorAsignaturaViewModel modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            datosAsignatura.AsignaturaEditar(modelo);

            return Redirect("Asignatura");

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEliminar(int Id)
        {

            TempData["MensajeEliminarA"] = "Asignatura Eliminada con exito";

            datosAsignatura.AsignaturaEliminar(Id);

            return Redirect("Asignatura");
        }
    }

}