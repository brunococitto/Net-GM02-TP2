using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class EditComisionViewModel
    {
        public Comision Comision { get; }
        public List<SelectListItem> Planes { get; }
        public EditComisionViewModel(Comision comision, IEnumerable<Plan> planes)
        {
            Comision = comision;
            Planes = planes.
                Select(p => new SelectListItem
                    { Text = $"{p.Descripcion} : {p.Especialidad.Descripcion}", Value = p.ID.ToString(), Selected = p.ID == comision?.IDPlan }
                ).ToList();
        }
    }
}
