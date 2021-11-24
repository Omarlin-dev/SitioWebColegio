using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Datos
{
    public class administradorDatos
    {
        public List<administradorViewModel> GetData()
        {
            List<administradorViewModel> lst = new List<administradorViewModel>();
            using (var db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<administradorViewModel>>(db.Administrador.ToList());

            }

            return lst;
        }
                
        public void Nuevo(administradorViewModel model)
        {       

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 1;
                var admin = AutoMapper.Mapper.Map<Administrador>(model);

                db.Administrador.Add(admin);
                db.SaveChanges();
            }
        }

        public administradorViewModel ConsultarAdmin(int Id)
        {
            administradorViewModel model = new administradorViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                Administrador adminbd = db.Administrador.FirstOrDefault(d => d.idAdmin == Id);
                model = AutoMapper.Mapper.Map<administradorViewModel>(adminbd);
            }
            return model;
        }

        public void Editar(administradorViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 1;
                var admin = AutoMapper.Mapper.Map<Administrador>(model);

                db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var admindb = db.Administrador.FirstOrDefault(d => d.idAdmin == Id);

                db.Administrador.Remove(admindb);
                db.SaveChanges();

            }
        }
    }
}