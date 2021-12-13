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
        [Autorizados(idOperacionadmin: 0, idOperacionProfesor: 0, idOperacionAlumno: 11)]
        public ActionResult IndexProfesores()
        {
            return View();
        }

        [Autorizados(idOperacionadmin: 0, idOperacionProfesor: 9, idOperacionAlumno: 0)]
        public ActionResult AlumnosProfesor()
        {
            var lst = datosProfesor.GetDataAlumnosProfesores();

            return View(lst);

        }

        [Autorizados(idOperacionadmin: 0, idOperacionProfesor: 9, idOperacionAlumno: 0)]
        public ActionResult MateriasProfesor()
        {
            var lst = datosProfesor.GetDataAsignaturaProfesor();

            return View(lst);

        }

        [Autorizados(idOperacionadmin: 0, idOperacionProfesor: 9, idOperacionAlumno: 0)]
        public ActionResult AlumnosAsignaturaProfesor(int Id)
        {
            var lst = datosProfesor.GetDataAsignaturaAlumnosProfesor(Id);

            return View(lst);
        }

        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 0, idOperacionAlumno: 0)]
        public ActionResult DetalleProfesor(int Id)
        {
            var profesor = datosProfesor.DetalleProfesor(Id);
            return View(profesor);
        }

        [Autorizados(idOperacionAlumno:13, 0)]
        public ActionResult DetalleProfesorAlumno(int Id)
        {
            var profesor = datosProfesor.detalleProfesorAlumno(Id);
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

        public ActionResult GetDataProfesorAlumno()
        {
            var lst = datosProfesor.GetDataProfesoresAlumno();
            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Nuevo()
        {
            return View();
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Nuevo(ProfesorOnlyViewModel model)
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
        public ActionResult Editar(ProfesorOnlyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            datosProfesor.Editar(model);

            return Redirect("IndexAdmin");

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Eliminar(int Id)
        {
           
           bool resultadoEliminar =datosProfesor.Eliminar(Id);
            if (resultadoEliminar)
            {
                TempData["MensajeEliminarP"] = "Profesor/a Eliminado/a con exito";
            }
            else
            {
                TempData["MensajeEliminarP"] = "No se puede eliminar este Profesor, tiene asignaturas asignadas";

            }
            return Redirect("IndexAdmin");
        }


        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Asignatura()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarA"];

            var lst = datosAsignatura.GetAsignaturas();

            return View(lst);
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
           bool resultadoEliminar = datosAsignatura.AsignaturaEliminar(Id);

            if (resultadoEliminar)
            {
                TempData["MensajeEliminarA"] = "Asignatura Eliminada con exito";
            }
            else
            {
                TempData["MensajeEliminarA"] = "No se puede elimnar esta Asignatura, tiene asignaturas de alumnos Asignadas";

            }


            return Redirect("Asignatura");
        }
    }

}