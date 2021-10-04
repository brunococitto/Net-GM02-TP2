using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class EditAlumnoInscripcionViewModel
    {
        public AlumnoInscripcion AlumnoInscripcion { get; }
        public List<SelectListItem> Cursos { get; }
        public List<SelectListItem> Personas { get; }
        public EditAlumnoInscripcionViewModel(AlumnoInscripcion alumnoinscripcion, IEnumerable<Curso> cursos, IEnumerable<Persona> personas)
        {
            AlumnoInscripcion = alumnoinscripcion;
            Cursos = cursos.
                Select(c => new SelectListItem
                {
                    Text = $"{ c.Descripcion}",
                    Value = c.ID.ToString(),
                    Selected = c.ID == alumnoinscripcion?.IDCurso
                }).ToList();

            

        }
    }
}
