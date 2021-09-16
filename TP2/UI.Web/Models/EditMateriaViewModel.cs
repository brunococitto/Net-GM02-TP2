using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class EditMateriaViewModel
    {
        public Materia Materia { get; }
        public List<SelectListItem> Planes { get; }
        public EditMateriaViewModel(Materia materia, IEnumerable<Plan> planes)
        {
            Materia = materia;
            Planes = planes.
                Select(p => new SelectListItem
                    { Text = $"{p.Especialidad.Descripcion}:{p.Descripcion}", Value = p.ID.ToString(), Selected = p.ID == materia?.IDPlan }
                ).ToList();
        }
    }
}
