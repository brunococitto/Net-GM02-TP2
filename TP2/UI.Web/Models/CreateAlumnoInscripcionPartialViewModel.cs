using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    
    public class CreateAlumnoInscripcionPartialViewModel
    {
        public AlumnoInscripcion AlumnoInscripcion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public CreateAlumnoInscripcionPartialViewModel(Persona? persona)
        {
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            AlumnoInscripcion = new AlumnoInscripcion()
            {
                IDAlumno = persona.ID
            };
        }
    }
}
