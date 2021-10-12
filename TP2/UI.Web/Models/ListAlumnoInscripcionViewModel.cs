using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{

    public class ListAlumnoInscripcionViewModel
    {
        public List<AlumnoInscripcion> Inscripciones { get; set; }
        public List<Curso> Cursos { get; set; }
        public ListAlumnoInscripcionViewModel(List<AlumnoInscripcion> inscripciones, List<Curso> cursos)
        {
            Inscripciones = inscripciones;
            Cursos = cursos;
        }
    }
}
