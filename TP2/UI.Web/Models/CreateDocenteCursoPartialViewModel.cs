using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    
    public class CreateDocenteCursoPartialViewModel
    {
        public DocenteCurso? DocenteCurso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public CreateDocenteCursoPartialViewModel(Persona? persona)
        {
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            
            DocenteCurso = new DocenteCurso()
            {
                IDDocente = persona.ID
            };
        }
    }
}
