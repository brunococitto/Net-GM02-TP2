using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateCursoViewModel
    {
        public Curso? Curso { get; }
        public List<SelectListItem> Materias { get; }
        public List<SelectListItem> Comisiones { get; }
        public CreateCursoViewModel(Curso? curso, IEnumerable<Materia> materias, IEnumerable<Comision> comisiones)
        {
            Curso = curso;
            Materias = materias.
                Select(m => new SelectListItem
                { Text = $"{m.Descripcion}", Value = m.ID.ToString() }
                ).ToList();
            Comisiones = comisiones.
                Select(c => new SelectListItem
                { Text = $"{c.Descripcion}", Value = c.ID.ToString() }
                ).ToList();
        }
    }
}
