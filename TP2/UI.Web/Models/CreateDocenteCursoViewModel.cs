using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateDocenteCursoViewModel
    {
        public DocenteCurso? DocenteCurso { get; }
        public List<SelectListItem> Personas { get; }
        public List<SelectListItem> Cursos { get; }
        public List<SelectListItem> TiposCargo { get; }


        public CreateDocenteCursoViewModel(DocenteCurso? docenteCurso, IEnumerable<Persona> personas, IEnumerable<Curso> cursos)
        {
            DocenteCurso = docenteCurso;
            Personas = personas.
                Select(p => new SelectListItem
                { Text = $"{p.Legajo}", Value = p.ID.ToString() }
                ).ToList();

            Cursos = cursos.
                Select(c => new SelectListItem
                { Text = $"{c.Descripcion}", Value = c.ID.ToString()}
                ).ToList();

            TiposCargo = Enum.GetValues(typeof(DocenteCurso.TiposCargo)).Cast<DocenteCurso.TiposCargo>().Select
            (tc => new SelectListItem
            {
                Text = tc.ToString(),
                Value = ((int)tc).ToString()
            }).ToList();
        }
    }
}
