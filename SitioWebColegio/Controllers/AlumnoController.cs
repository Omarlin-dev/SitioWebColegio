using Microsoft.Ajax.Utilities;
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
        // GET: Alumno
        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 8, idOperacionAlumno: 13)]
        public ActionResult TodosAlumnos()
        {
            return View();

        }

        public ActionResult GetDataAlumnosTodos()
        {

            List<AlumnosViewModels> lst = new List<AlumnosViewModels>();
            using (var db = new DBColegioEntities())
            {
                lst = (from d in db.Alumno
                       select new AlumnosViewModels
                       {
                           idAlumno = d.idAlumno,
                           nombre = d.nombre,
                           apellido = d.apellido,
                           telefono = d.telefono
                       }).ToList();

            }

            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);

        }

        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 9, idOperacionAlumno: 14)]
        public ActionResult DetalleAlumno(int Id)
        {
            var oAlumno = new alumnoViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var Alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);

                oAlumno.alumno = Alumnodb;

                oAlumno.asignaturas = db.Asignatura.Where(d => d.idAlumno == Id).ToList();
            }

            return View(oAlumno);
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult TodosAlumnosAdmin()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarP"];

            return View();
        }

        public ActionResult GetDataAlumnos()
        {

            List<AlumnosViewModels> lst = new List<AlumnosViewModels>();
            using (var db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<AlumnosViewModels>>(db.Alumno.ToList());

            }

            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);

        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult NuevoAlumno()
        {
            return View();
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult NuevoAlumno(alumnoViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.alumno.idRol = 3;
                var oAlumno = model.alumno; 

                db.Alumno.Add(oAlumno);
                db.SaveChanges();
            }
            return Redirect("TodosAlumnosAdmin");
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult EditarAlumno(int Id)
        {
            alumnoViewModel model = new alumnoViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
               var alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);
                model.alumno = alumnodb;
            }
            return View(model);
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult EditarAlumno(alumnoViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.alumno.idRol = 3;
                var alumnodb = model.alumno;

                db.Entry(alumnodb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("TodosAlumnosAdmin");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult EliminarAlumno(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);
                TempData["MensajeEliminarP"] = "Alumno/a: " + alumnodb.nombre + " Eliminado con exito";

                db.Alumno.Remove(alumnodb);
                db.SaveChanges();

            }
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
            var lst = new List<asignaturaViewModel>();
            using (DBColegioEntities db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaNuevoAlumno()
        {
            var model = new AlumnoProfesorAsignaturaViewModel();


            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.profesorList = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
                model.alumnoList = db.Alumno.ToList();

                model.asignaturaList = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return View(model);
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaNuevoAlumno(AlumnoProfesorAsignaturaViewModel omodel)
        {
            if (!ModelState.IsValid)
                return View(omodel);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);


                db.Asignatura.Add(asignaturadb);

                db.SaveChanges();
            }

            return Redirect("AsignaturaAlumno");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEditarAlumno(int Id)
        {
            var model = new AlumnoProfesorAsignaturaViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.AsignaturaFirst = AutoMapper.Mapper.Map<asignaturaViewModel>(db.Asignatura.FirstOrDefault(d => d.idAsignatura == Id));
                model.profesorList = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
                model.alumnoList = db.Alumno.ToList();

                model.asignaturaList = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return View(model);
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult AsignaturaEditarAlumno(AlumnoProfesorAsignaturaViewModel omodel)
        {

            if (!ModelState.IsValid)
                return View(omodel);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);


                db.Entry(asignaturadb).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Redirect("AsignaturaAlumno");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEliminarAlumno(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var oAsignatura = db.Asignatura.FirstOrDefault(d => d.idAsignatura == Id);

                TempData["MensajeEliminarA"] = "Asignatura: " + oAsignatura.nombre + " Eliminada con exito";

                db.Asignatura.Remove(oAsignatura);
                db.SaveChanges();

            }
            return Redirect("AsignaturaAlumno");
        }
    }
}