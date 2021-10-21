using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;

namespace SitioWebColegio.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminar"];

            List<administradorViewModel> lst = new List<administradorViewModel>();
            using (var db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<administradorViewModel>>(db.Administrador.ToList());

            }

            return View(lst);
        }

                
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(administradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 1;
                var admin = AutoMapper.Mapper.Map<Administrador>(model);

                db.Administrador.Add(admin);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult Editar(int Id)
        {
            administradorViewModel model = new administradorViewModel();

            using(DBColegioEntities db = new DBColegioEntities())
            {
                Administrador adminbd = db.Administrador.FirstOrDefault(d => d.idAdmin == Id);
                model = AutoMapper.Mapper.Map<administradorViewModel>(adminbd);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(administradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 1;
                var admin = AutoMapper.Mapper.Map<Administrador>(model);

                db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var admindb = db.Administrador.FirstOrDefault(d => d.idAdmin == Id);
                TempData["MensajeEliminar"] = "Usuario: " + admindb.nombre + " Eliminado con exito";

                db.Administrador.Remove(admindb);
                db.SaveChanges();

            }
            return Redirect("Index");

        }
    }
}