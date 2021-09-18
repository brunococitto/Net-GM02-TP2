using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateComisionViewModel
    {
        public Comision? Comision { get; }
        public List<SelectListItem> Planes { get; }
        public CreateComisionViewModel(Comision? comision, IEnumerable<Plan> planes)
        {
            Comision = comision;
            Planes = planes.
                Select(p => new SelectListItem
                    { Text = $"{p.Descripcion} : {p.Especialidad.Descripcion}", Value = p.ID.ToString()}
                ).ToList();
        }
    }
}
