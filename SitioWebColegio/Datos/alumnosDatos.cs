using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Datos
{
    public class alumnosDatos
    {
        public List<AlumnosViewModels> GetDataAlumnnos()
        {
            using(DBColegioEntities db = new DBColegioEntities())
            {
                var oAlumno = AutoMapper.Mapper.Map<List<AlumnosViewModels>>(db.Alumno.ToList());
                return oAlumno;
            }
        }

        public List<Alumno> ConsultarAlumno()
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                return db.Alumno.ToList();
            }
        }

        public alumnoViewModel ConsultarAlumno(int Id)
        {
            var oAlumno = new alumnoViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var Alumnodb = db.Alumno.FirstOrDefault(d => d.idAlumno == Id);

                oAlumno.alumno = Alumnodb;

                oAlumno.nombreAsignatura = oAlumno.asignaturas.Select(d => d.nombre).Distinct().ToList();

            }

            return oAlumno;
        }

        public Alumno ConsultarOneAlumno(int Id)
        {

            using (DBColegioEntities db = new DBColegioEntities())
            {
                return db.Alumno.FirstOrDefault(d => d.idAlumno == Id);
            }
        }

        public void Guardar(Alumno modelo)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                modelo.idRol = 3;
                db.Alumno.Add(modelo);
                db.SaveChanges();
            }
        }

        public void Editar(Alumno modelo)
        {
            using(DBColegioEntities db = new DBColegioEntities())
            {
                modelo.idAlumno = 3;
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
               var alumno= db.Alumno.FirstOrDefault(d => d.idAlumno == Id);
                db.Alumno.Remove(alumno);
                db.SaveChanges();
            }
        }

    }
}