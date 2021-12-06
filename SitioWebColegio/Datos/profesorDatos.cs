using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Datos
{
    public class profesorDatos
    {   
        public profesorViewModel DetalleProfesor(int Id)
        {
            var profesor = new profesorViewModel();

            using (var db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);

                profesor = AutoMapper.Mapper.Map<profesorViewModel>(profesordb);


                profesor.asiginaturas = db.Asignatura.Where(d => d.idProfesor == profesor.idProfesor).ToList();

                profesor.nombreAsignatura = profesor.asiginaturas.Select(d => d.nombre).Distinct().ToList();
            }

            return profesor;
        }

        public List<profesorViewModel> GetDataProfesores()
        {
            var lst = new List<profesorViewModel>();
            using (DBColegioEntities db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<profesorViewModel>>(db.Profesor.ToList());
            }

            return lst;
        }

        public void Nuevo(profesorViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oProfesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Profesor.Add(oProfesor);
                db.SaveChanges();
            }
        }

        public profesorViewModel ConsultarProfesor(int Id)
        {
            profesorViewModel model = new profesorViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                Profesor Profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);
                model = AutoMapper.Mapper.Map<profesorViewModel>(Profesordb);
            }

            return model;
        }

        public void Editar(profesorViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oprofesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Entry(oprofesor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);

            if(profesordb.idProfesor != db.Asignatura.FirstOrDefault(d => d.idProfesor == profesordb.idProfesor)?.idProfesor)
             {
                    db.Profesor.Remove(profesordb);
                    db.SaveChanges();
                    return true;
             }
                return false;
            }
        }
        

        public List<asignaturaViewModel> GetDataProfesoresAsignaturas()
        {
            var lst = new List<asignaturaViewModel>();
            using (DBColegioEntities db = new DBColegioEntities())
            {
                lst = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return lst;
        }
      
    }
}