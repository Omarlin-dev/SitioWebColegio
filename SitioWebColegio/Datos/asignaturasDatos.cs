using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;

namespace SitioWebColegio.Datos
{
    public class asignaturasDatos
    {
        public AlumnoProfesorAsignaturaViewModel ConsultarAsignatura()
        {
            var model = new AlumnoProfesorAsignaturaViewModel();


            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.profesorList = db.Profesor.ToList();

            }

            return model;
        }
              

        public List<Asignatura> GetAsignaturas()
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var lst = db.Asignatura.Include("Profesor").ToList();

                return lst;

            }

        }

       

        public void AsignaturaNuevo(AlumnoProfesorAsignaturaViewModel omodel)
        {

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);

                db.Asignatura.Add(asignaturadb);

                db.SaveChanges();
            }

        }

        public AlumnoProfesorAsignaturaViewModel AsignaturaEditar(int Id)
        {
            var model = new AlumnoProfesorAsignaturaViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.AsignaturaFirst = db.Asignatura.FirstOrDefault(d => d.idAsignatura == Id);
                model.profesorList = db.Profesor.ToList();
                model.profesorFirts = db.Profesor.FirstOrDefault(d => d.idProfesor == model.AsignaturaFirst.idProfesor);

                model.asignaturaList = db.Asignatura.ToList();
            }

            return model;
        }

        public void AsignaturaEditar(AlumnoProfesorAsignaturaViewModel omodel)
        {

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturadb = AutoMapper.Mapper.Map<Asignatura>(omodel.AsignaturaFirst);

                db.Entry(asignaturadb).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public bool AsignaturaEliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var oAsignatura = db.Asignatura.FirstOrDefault(d => d.idAsignatura == Id);

                if(oAsignatura.idAsignatura != db.AsignaturaAlumno.FirstOrDefault(d => d.idAsignatura == oAsignatura.idAsignatura)?.idAsignatura)
                {
                    db.Asignatura.Remove(oAsignatura);
                    db.SaveChanges();

                    return true;
                }
                return false;

            }
        }
    }
}