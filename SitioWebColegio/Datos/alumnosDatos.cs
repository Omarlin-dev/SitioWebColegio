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

        public List<Asignatura> GetDataMateriaAlumnos()
        {
            var alumno = (Alumno)HttpContext.Current.Session["Alumno"];

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignaturaProfesor = (from asignaturaAlumno in db.AsignaturaAlumno.Where(d => d.idAlumno == alumno.idAlumno).ToList()
                                          join asignatura in db.Asignatura.Include("Profesor").ToList()
                                          on asignaturaAlumno.idAsignatura equals asignatura.idAsignatura
                                          select asignatura).ToList();

                return asignaturaProfesor;
            }          
        }

        public List<Alumno> GetDataCompanerosClase(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var AlumnosClase = (from asignatura in db.Asignatura.Where(d => d.idAsignatura == Id).ToList()
                                          join asignaruraAlumno in db.AsignaturaAlumno.ToList()
                                          on asignatura.idAsignatura equals asignaruraAlumno.idAsignatura
                                          join alumnos in db.Alumno.ToList()
                                          on asignaruraAlumno.idAlumno equals alumnos.idAlumno
                                          select alumnos).ToList();

                return AlumnosClase;
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

                var asignaturaAlumno = db.AsignaturaAlumno.Where(d => d.idAlumno == Id).ToList();

                oAlumno.asignaturas = (from d in asignaturaAlumno
                                       join e in db.Asignatura.ToList() on d.idAsignatura equals e.idAsignatura
                                       select e).ToList();

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

        public bool Eliminar(int Id)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
               var alumno= db.Alumno.FirstOrDefault(d => d.idAlumno == Id);

                if(alumno.idAlumno != db.AsignaturaAlumno.FirstOrDefault(d => d.idAlumno == alumno.idAlumno)?.idAlumno)
                {
                    db.Alumno.Remove(alumno);
                    db.SaveChanges();
                    return true;
                }

                return false;
                
            }
        }

    }
}