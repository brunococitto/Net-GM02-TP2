using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreatePersonaViewModel
    {
        public Persona? Persona { get; }
        public List<SelectListItem> Planes { get; }

        public List<SelectListItem> TiposPersona { get; }


        public CreatePersonaViewModel(Persona? persona, IEnumerable<Plan> planes)
        {
            Persona = persona;
            Planes = planes.
                Select(p => new SelectListItem
                { Text = $"{p.Descripcion} : {p.Especialidad.Descripcion}", Value = p.ID.ToString() }
                ).ToList();
            TiposPersona = Enum.GetValues(typeof(Persona.TiposPersona)).Cast<Persona.TiposPersona>().Select
            (v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
        }
    }
}
