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
        public List<SelectListItem> Cursos { get; }
        public List<SelectListItem> TiposCargo { get; }
        public CreateDocenteCursoViewModel(DocenteCurso? docenteCurso, IEnumerable<Curso> cursos)
        {
            DocenteCurso = docenteCurso;
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
