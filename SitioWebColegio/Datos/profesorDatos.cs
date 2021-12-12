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
        public ProfesorAsignaturaViewModel DetalleProfesor(int Id)
        {
            var profesor = new ProfesorAsignaturaViewModel();

            using (var db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);

                profesor = AutoMapper.Mapper.Map<ProfesorAsignaturaViewModel>(profesordb);


                profesor.asiginaturas = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.Where(d => d.idProfesor == profesor.idProfesor)).ToList();

                profesor.nombreAsignatura = profesor.asiginaturas.Select(d => d.nombre).Distinct().ToList();
            }

            return profesor;
        }

        public List<ProfesorOnlyViewModel> GetDataProfesores()
        {
            var lst = new List<ProfesorOnlyViewModel>();
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var profesor = db.Profesor.ToList();
               
                lst = AutoMapper.Mapper.Map<List<ProfesorOnlyViewModel>>(profesor);
            }

            return lst;
        }

        public List<ProfesorOnlyViewModel> GetDataProfesoresAlumno()
        {
            var alumno = (Alumno)HttpContext.Current.Session["Alumno"];

            var lst = new List<ProfesorOnlyViewModel>();
            using (DBColegioEntities db = new DBColegioEntities())
            {
                var profesor = (from alumnoAsig in
                                    db.AsignaturaAlumno.Where(d => d.idAlumno == alumno.idAlumno).ToList()
                                join asignatura in db.Asignatura.ToList()
                                on alumnoAsig.idAsignatura equals asignatura.idAsignatura
                                where alumnoAsig.idAsignatura == asignatura.idAsignatura
                                join profesorjoin in db.Profesor.ToList()
                                on asignatura.idProfesor equals profesorjoin.idProfesor
                                where profesorjoin.idProfesor == asignatura.idProfesor
                                select profesorjoin).ToList();
                                

                lst = AutoMapper.Mapper.Map<List<ProfesorOnlyViewModel>>(profesor);
            }

            return lst;
        }

        public List<Asignatura> GetDataAsignaturaProfesor()
        {
            var profesor = (Profesor)HttpContext.Current.Session["Profesor"];

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var asignatura = (from profesores in
                                    db.Profesor.Where(d => d.idProfesor == profesor.idProfesor).ToList()
                                join asignaturas in db.Asignatura.Include("Profesor").ToList()
                                on profesores.idProfesor equals asignaturas.idProfesor                                
                                select asignaturas).ToList();

                return asignatura;
            }
        }

        public List<AsignaturaAlumno> GetDataAlumnosProfesores()
        {
            var profesor = (Profesor)HttpContext.Current.Session["Profesor"];

            using (DBColegioEntities db = new DBColegioEntities())
            {
                var MisAlumnos = (from profesores in db.Profesor.Where(d => d.idProfesor == profesor.idProfesor).ToList()
                                  join asignatura in db.Asignatura.ToList()
                                  on profesores.idProfesor equals asignatura.idProfesor
                                  join asignaturaAlumno in db.AsignaturaAlumno.Include("Asignatura").Include("Alumno").ToList()
                                  on asignatura.idAsignatura equals asignaturaAlumno.idAsignatura
                                  join alumnos in db.Alumno.ToList()
                                  on asignaturaAlumno.idAlumno equals alumnos.idAlumno
                                  select asignaturaAlumno).ToList();

                return MisAlumnos;
            }
        }

        public ProfesorAsignaturaViewModel detalleProfesorAlumno(int Id)
        {
            var profesor = new ProfesorAsignaturaViewModel();

            using (var db = new DBColegioEntities())
            {
                var profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);

                profesor.profesorone = AutoMapper.Mapper.Map<ProfesorOnlyViewModel>(profesordb);

                profesor.asignatura = db.Asignatura.FirstOrDefault(d => d.idProfesor == Id);

            }

            return profesor;

        }

        public void Nuevo(ProfesorOnlyViewModel model)
        {
            using (DBColegioEntities db = new DBColegioEntities())
            {
                model.idRol = 2;
                var oProfesor = AutoMapper.Mapper.Map<Profesor>(model);

                db.Profesor.Add(oProfesor);
                db.SaveChanges();
            }
        }

        public ProfesorOnlyViewModel ConsultarProfesor(int Id)
        {
            ProfesorOnlyViewModel model = new ProfesorOnlyViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                Profesor Profesordb = db.Profesor.FirstOrDefault(d => d.idProfesor == Id);
                model = AutoMapper.Mapper.Map<ProfesorOnlyViewModel>(Profesordb);
            }

            return model;
        }

        public void Editar(ProfesorOnlyViewModel model)
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