using Microsoft.Ajax.Utilities;
using SitioWebColegio.Datos;
using SitioWebColegio.Filtro;
using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebColegio.Controllers
{
    public class AlumnoController : Controller
    {
        private alumnosDatos datos = new alumnosDatos();
        private alumnoAsignaturaDatos datosAsignatura = new alumnoAsignaturaDatos();

        // GET: Alumno
        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 8, idOperacionAlumno: 13)]
        public ActionResult TodosAlumnos()
        {
            return View();

        }

        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 9, idOperacionAlumno: 14)]
        public ActionResult DetalleAlumno(int Id)
        {
            var lst = datos.ConsultarAlumno(Id);
            return View(lst);
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult TodosAlumnosAdmin()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarP"];

            return View();
        }

        public ActionResult GetDataAlumnos()
        {

            return Json(new { data = datos.GetDataAlumnnos() }, JsonRequestBehavior.AllowGet);

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult NuevoAlumno()
        {
            return View();
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult NuevoAlumno(Alumno modelo)
        {

            if (!ModelState.IsValid)
                return View(modelo);

            datos.Guardar(modelo);
            return Redirect("TodosAlumnosAdmin");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult EditarAlumno(int Id)
        { 
            var lst = datos.ConsultarOneAlumno(Id);
            return View(lst); 
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult EditarAlumno(Alumno modelo)
        {

            if (!ModelState.IsValid)
                return View(modelo);

            datos.Editar(modelo);

            return Redirect("TodosAlumnosAdmin");

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult EliminarAlumno(int Id)
        {
                datos.Eliminar(Id);
                TempData["MensajeEliminarP"] = "Alumno Eliminado con exito";                         

            return Redirect("TodosAlumnosAdmin");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaAlumno()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarA"];

            return View();
        }

        public ActionResult GetDataAlumnosAsignaturas()
        {
            var lst = datosAsignatura.GetAsignaturas();

            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaNuevoAlumno()
        {
            var modelo = datosAsignatura.consultarGuardarAsignatura();

            return View(modelo);
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaNuevoAlumno(asignaturaAlumnoViewModel modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            datosAsignatura.GuardarAsignatura(modelo);

            return Redirect("AsignaturaAlumno");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEditarAlumno(int Id)
        {
            var modelo = new asignaturaAlumnoViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                modelo.oneAsignaturasAlumnos = db.AsignaturaAlumno.FirstOrDefault(d => d.Id == Id);
                modelo.oneAsignaturas = AutoMapper.Mapper.Map<asignaturaViewModel>(db.Asignatura.FirstOrDefault(d => d.idAsignatura == modelo.oneAsignaturasAlumnos.idAsignatura));
                modelo.oneAlumnos = AutoMapper.Mapper.Map<AlumnosViewModels>(db.Alumno.FirstOrDefault(d => d.idAlumno == modelo.oneAsignaturasAlumnos.idAlumno));


                modelo.alumnos = AutoMapper.Mapper.Map<List<AlumnosViewModels>>(db.Alumno.ToList());
                modelo.asignaturas = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());


            }

            return View(modelo);
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaEditarAlumno(asignaturaAlumnoViewModel modelo)
        {

            if (!ModelState.IsValid)
                return View(modelo);

            datosAsignatura.EditarAsignatura(modelo);

            return Redirect("AsignaturaAlumno");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEliminarAlumno(int Id)
        {
            datosAsignatura.EliminarAsignatura(Id);

            TempData["MensajeEliminarA"] = "Asignatura Eliminada con exito";
                       
            return Redirect("AsignaturaAlumno");
        }
    }
}