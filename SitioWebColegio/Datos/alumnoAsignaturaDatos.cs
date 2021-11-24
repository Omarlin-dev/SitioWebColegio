using SitioWebColegio.Models;
using SitioWebColegio.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitioWebColegio.Datos
{
    public class alumnoAsignaturaDatos
    {
        public List<alumnosAsignaturaViewModel> GetAsignaturas()
        {
            using (var db = new DBColegioEntities())
            {
                var oAsignatura = AutoMapper.Mapper.Map<List<alumnosAsignaturaViewModel>>(db.AsignaturaAlumno.ToList());
                return oAsignatura;
            }
        }

    public asignaturaAlumnoViewModel consultarGuardarAsignatura()
        {
            var modelo = new asignaturaAlumnoViewModel();

            using (DBColegioEntities db = new DBColegioEntities())
            {
                modelo.alumnos = AutoMapper.Mapper.Map<List<AlumnosViewModels>>(db.Alumno.ToList());
                modelo.asignaturas = AutoMapper.Mapper.Map<List<asignaturaViewModel>>(db.Asignatura.ToList());
            }

            return modelo;
        }

        public void GuardarAsignatura(asignaturaAlumnoViewModel modelo)
        {
            using (var db = new DBColegioEntities())
            {
                var asignatura = modelo.alumnoAsignaturaGuardar;
                db.AsignaturaAlumno.Add(asignatura);
                db.SaveChanges();
            }
        }

        public void EditarAsignatura(asignaturaAlumnoViewModel modelo)
        {
            using (var db = new DBColegioEntities())
            {
                var asignatura = AutoMapper.Mapper.Map<AsignaturaAlumno>(modelo.alumnoAsignaturaGuardar);
                asignatura.Id = modelo.oneAsignaturasAlumnos.Id;

                db.Entry(asignatura).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void EliminarAsignatura(int Id)
        {
            using (var db = new DBColegioEntities())
            {
                var modelo = db.AsignaturaAlumno.FirstOrDefault(d=> d.Id == Id);
                db.AsignaturaAlumno.Remove(modelo);
                db.SaveChanges();
            }
        }
    }
}