using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitioWebColegio.Models.viewModels;
using SitioWebColegio.Models;

namespace SitioWebColegio.AutomapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Administrador, administradorViewModel>();
            CreateMap<administradorViewModel, Administrador>();

            CreateMap<Alumno, alumnoViewModel>();
            CreateMap<alumnoViewModel, Alumno>();

            CreateMap<Asignatura, asignaturaViewModel>();
            CreateMap<asignaturaViewModel, Asignatura>();

            CreateMap<Profesor, profesorViewModel>();
            CreateMap<profesorViewModel, Profesor>();

        }
    }
}