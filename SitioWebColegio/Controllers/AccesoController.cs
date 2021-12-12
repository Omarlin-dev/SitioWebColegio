using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioWebColegio.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            ViewBag.noExiste = ViewData["NoExiste"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        { 
        
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                using (DBColegioEntities db = new DBColegioEntities())
                {
                    if (model.Rol == "Administrador")
                    {
                        var oUser = (from d in db.Administrador
                                     where d.nombreusuario == model.NameUser.Trim() && d.clave == model.Clave.Trim()
                                     select d).FirstOrDefault();

                        if (oUser == null)
                        {
                            ViewData["NoExiste"] = "Usuario o Clave incorrecta";
                            return View();
                        }

                        Session["Administrador"] = oUser; 
                        Session["userTitulo"] = oUser.nombre;
                        return RedirectToAction("Index", "Administrador");

                    }

                    if (model.Rol == "Profesor")
                    {
                        var oUser = (from d in db.Profesor
                                     where d.nombreUsuario == model.NameUser.Trim() && d.clave== model.Clave.Trim()
                                     select d).FirstOrDefault();
                         
                        if (oUser == null)
                        {
                            ViewData["NoExiste"] = "Usuario o Clave incorrecta";
                            return View();
                        }

                        Session["Profesor"] = oUser;
                        Session["userTitulo"] = oUser.nombre;
                        return RedirectToAction("AlumnosProfesor", "Profesor");

                    }

                    if (model.Rol == "Alumno")
                    {
                        var oUser = (from d in db.Alumno
                                     where d.nombreUsuario == model.NameUser.Trim() && d.clave == model.Clave.Trim()
                                     select d).FirstOrDefault();

                        if (oUser == null)
                        {
                            ViewData["NoExiste"] = "Usuario o Clave incorrecta";
                            return View();
                        }

                        Session["Alumno"] = oUser;
                        Session["userTitulo"] = oUser.nombre;

                        return RedirectToAction("MateriasAlumnos", "Alumno");
                    }
                }
          
            }

            catch (Exception ex)
            {
                return View();
            }

           return View();


        }

        public ActionResult Logof()
        {
            Session["Administrador"] = null;
            Session["Profesor"] = null;
            Session["Alumno"] = null;
            Session["userTitulo"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}