using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreatePlanViewModel
    {
        public Plan? Plan { get; }
        public List<SelectListItem> Especialidades { get; }
        public CreatePlanViewModel(Plan? plan, IEnumerable<Especialidad> especialidades)
        {
            Plan = plan;
            Especialidades = especialidades.
                Select(e => new SelectListItem
                    { Text = $"{e.Descripcion}", Value = e.ID.ToString()}
                ).ToList();
        }
    }
}
