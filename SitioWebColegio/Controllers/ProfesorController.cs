using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;
using SitioWebColegio.Filtro;

namespace SitioWebColegio.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesores
        [Autorizados(idOperacionadmin:1, idOperacionProfesor:6, idOperacionAlumno:11)]
        public ActionResult IndexProfesores()
        {
            var lstProfesor = new List<profesorViewModel>();

            using (var db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
            }
            return View(lstProfesor);
        }

        [Autorizados(idOperacionadmin: 1, idOperacionProfesor: 7, idOperacionAlumno: 12)]
        public ActionResult DetalleProfesor(int Id)
        {
            var profesor = new profesorViewModel();

            using (var db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);

                profesor = AutoMapper.Mapper.Map<profesorViewModel>(profesordb);

                profesor.asiginaturas = db.Asignatura.Where(d => d.idProfesor == Id).ToList();

            }
            return View(profesor);
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult IndexAdmin()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarP"];

            var lstProfesor = new List<profesorViewModel>();

            using (var db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
            }
            return View(lstProfesor);
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

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oProfesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Profesor.Add(oProfesor);
                db.SaveChanges();
            }
            return Redirect("IndexAdmin");
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Editar(int Id)
        {
            profesorViewModel model = new profesorViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                Profesor Profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);
                model = AutoMapper.Mapper.Map<profesorViewModel>(Profesordb);
            }
            return View(model);
        }
        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Editar(profesorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oprofesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Entry(oprofesor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("IndexAdmin");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);
                TempData["MensajeEliminarP"] = "Profesor/a: " + profesordb.nombre + " Eliminado/a con exito";

                db.Profesor.Remove(profesordb);
                db.SaveChanges();

            }
            return Redirect("IndexAdmin");
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Asignatura()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarA"];

            var model = new AlumnoProfesorAsignaturaViewModel();
            
            using(DBColegioEntities db = new DBColegioEntities())
            {
                model.asignaturaList = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }
                                                                                                                                                                              
            return View(model);
        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaNuevo()
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
    public ActionResult AsignaturaNuevo(AlumnoProfesorAsignaturaViewModel omodel)
    {

            if (!ModelState.IsValid)
                return View(omodel);

            using (DBColegioEntities db = new DBColegioEntities())
        {
          var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);

                db.Asignatura.Add(asignaturadb);

                db.SaveChanges();
        }

            return Redirect("Asignatura");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEditar(int Id)
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
        public ActionResult AsignaturaEditar(AlumnoProfesorAsignaturaViewModel omodel)
        {
            if (!ModelState.IsValid)
                return View(omodel);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);


                db.Entry(asignaturadb).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Redirect("Asignatura");

        }
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult AsignaturaEliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var oAsignatura = db.Asignatura.FirstOrDefault(d => d.idAsignatura == Id);

                TempData["MensajeEliminarA"] = "Asignatura: " + oAsignatura.nombre + " Eliminada con exito";

                db.Asignatura.Remove(oAsignatura);
                db.SaveChanges();

            }
            return Redirect("Asignatura");
    }
        }
   
}