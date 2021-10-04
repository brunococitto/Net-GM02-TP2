using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateAlumnoInscripcionViewModel
    {
        public AlumnoInscripcion? AlumnoInscripcion { get; }
        public Persona? Persona { get; }
        public List<SelectListItem> Cursos { get; }
        public List<SelectListItem> Personas { get; }
        public CreateAlumnoInscripcionViewModel(AlumnoInscripcion? alumnoinscipcion, IEnumerable<Curso> cursos, IEnumerable<Persona> personas)
        {
            AlumnoInscripcion = alumnoinscipcion;
            Cursos = cursos.
                Select(c => new SelectListItem
                { Text = $"{c.Descripcion}", Value = c.ID.ToString() }
                ).ToList();
            Personas = personas.
                Select(p => new SelectListItem
                { Text = $"{p.Nombre}", Value = p.ID.ToString() }
                ).ToList();
        }
    }
}
