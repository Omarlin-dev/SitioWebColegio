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
        public ActionResult TodosAlumnos()
        {
            var oAlumnos = new List<Alumno>();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                oAlumnos = db.Alumno.ToList();
            }

            return View(oAlumnos);
        }

        public ActionResult TodosAlumnosAdmin()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarP"];

            var oAlumnos = new List<Alumno>();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                oAlumnos = db.Alumno.ToList();
            }

            return View(oAlumnos);
        }
         
        public ActionResult DetalleAlumno(int Id)
        {
            var oAlumno = new alumnoViewModel();

            using(DBColegioEntities db = new DBColegioEntities())
            {
                var Alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);

                oAlumno.alumno = Alumnodb;

                oAlumno.asignaturas = db.Asignatura.Where(d => d.idAlumno == Id).ToList();
            }

            return View(oAlumno);
        }

        public ActionResult CompanerosAlumnos(int Id)
        {
            var  lstAlumno = new AlumnoProfesorAsignaturaViewModel();
            var oneAlumno = new alumnoViewModel();


            using (var db = new DBColegioEntities())
            {
                lstAlumno.asignaturaList = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.Where(d => d.idAlumno == Id));

                lstAlumno.asignaturaList.ForEach(d =>
                {
                    oneAlumno.alumno= db.Alumno.FirstOrDefault(i => i.idAlumno == d.idAlumno);
                    lstAlumno.alumnoList.Add(oneAlumno.alumno);
                });

                return View(lstAlumno);

            }

        }

        public ActionResult IndexProfesoresAlumno(int Id)
        {
            var asignatura = new asignaturaViewModel();
            var lstProfesores = new List<profesorViewModel>();
             
            using (var db = new DBColegioEntities())
            {
                asignatura = AutoMapper.Mapper.Map<asignaturaViewModel>(db.Asignatura.Where(d => d.idAlumno == Id));
                lstProfesores = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.Where(d => d.idProfesor == asignatura.idProfesor).ToList());
            }
            return View(lstProfesores);
        }       

       
        public ActionResult NuevoAlumno()
        {
            return View();
        }

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

        public ActionResult EliminarAlumno(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);
                TempData["MensajeEliminarP"] = "Alumno0/a: " + alumnodb.nombre + " Eliminado con exito";

                db.Alumno.Remove(alumnodb);
                db.SaveChanges();

            }
            return Redirect("TodosAlumnosAdmin");
        }

        public ActionResult AsignaturaAlumno()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminarA"];

            var model = new AlumnoProfesorAsignaturaViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.asignaturaList = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return View(model);
        }

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