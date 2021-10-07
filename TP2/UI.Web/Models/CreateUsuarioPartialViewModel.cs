using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateUsuarioPartialViewModel
    {
        public int IDPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public CreateUsuarioPartialViewModel(Persona? persona)
        {
            IDPersona = persona.ID;
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
        }
    }
}
