using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;

namespace SitioWebColegio.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesores
        public ActionResult IndexProfesores()
        {
            var lstProfesor = new List<profesorViewModel>();

            using(var db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
            }
            return View(lstProfesor);
        }

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

        public ActionResult IndexAdmin()
        {
            var lstProfesor = new List<profesorViewModel>();

            using (var db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
            }
            return View(lstProfesor);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(profesorViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oProfesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Profesor.Add(oProfesor);
                db.SaveChanges();
            }
            return Redirect("IndexAdmin");
        }

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

        [HttpPost]
        public ActionResult Editar(profesorViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oprofesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Entry(oprofesor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);
                ViewBag.mensajeEliminar = "Usuario: " + profesordb.nombre + " Eliminado con exito";

                db.Profesor.Remove(profesordb);
                db.SaveChanges();

            }
            return Redirect("IndexAdmin");
        }

        public ActionResult Asignatura()
        {
            var lstProfesor = new List<profesorViewModel>();
            var oprofesor = new profesorViewModel();

            using(DBColegioEntities db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
                oprofesor.asiginaturas = AutoMapper.Mapper.Map<List<Asignatura>>(db.Asignatura.ToList());
                lstProfesor.Add(oprofesor);
            }

            return View(lstProfesor);
        }

        public ActionResult AsignaturaNuevo()
        {
            var lstProfesor = new List<profesorViewModel>();
            var oprofesor = new profesorViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                lstProfesor = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
                lstProfesor.Add(oprofesor);
            }

            return View(lstProfesor);
        }
     
    [HttpPost]
    public ActionResult AsignaturaNuevo(profesorViewModel oProfesor)
    {
      

        using (DBColegioEntities db = new DBColegioEntities())
        {
          var oProfesordb = AutoMapper.Mapper.Map<Profesor>(oProfesor);

                db.Profesor.Add(oProfesordb);
                db.SaveChanges();
        }

            return Redirect("IndexAdmin");
        }
    }
   
}