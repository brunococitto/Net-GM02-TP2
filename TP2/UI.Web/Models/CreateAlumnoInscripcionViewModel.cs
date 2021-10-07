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
        public List<SelectListItem> Cursos { get; }

        public string Condicion { get; set; }
        public int Nota { get; set; }
        public CreateAlumnoInscripcionViewModel(AlumnoInscripcion? alumnoinscipcion, IEnumerable<Curso> cursos )
        {
            AlumnoInscripcion = alumnoinscipcion;
            Cursos = cursos.
                Select(c => new SelectListItem
                { Text = $"{c.Descripcion}", Value = c.ID.ToString() }
                ).ToList();

            Condicion = "";
            Nota = 0;
        }
    }
}
