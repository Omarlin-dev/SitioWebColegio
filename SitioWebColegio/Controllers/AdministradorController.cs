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
    public class AdministradorController : Controller
    {
        private administradorDatos admin = new administradorDatos();

        // GET: Administrador
        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Index()
        {
            ViewBag.mensajeEliminar = TempData["MensajeEliminar"];          

            return View();
        }

        public ActionResult GetData()
        {
            var lst = admin.GetData();
           
                return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
            
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Nuevo()
        {
            return View();
        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Nuevo(administradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            admin.Nuevo(model);

            return Redirect("Index");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Editar(int Id)
        {
            var modelo = admin.ConsultarAdmin(Id);

            return View(modelo);

        }

        [Autorizados(idOperacionadmin: 1)]
        [HttpPost]
        public ActionResult Editar(administradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            admin.Editar(model);

            return Redirect("Index");
        }

        [Autorizados(idOperacionadmin: 1)]
        public ActionResult Eliminar(int Id)
        {
            admin.Eliminar(Id);

                TempData["MensajeEliminar"] = "Usuario Eliminado con exito";
                           
            return Redirect("Index");

        }
    }
}