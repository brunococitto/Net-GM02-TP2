using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    
    public class ListEstadoAcademicoViewModel
    {
        public List<Object> EstadoAcademico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public string Plan { get; set; }
        public string Especialidad { get; set; }
        public ListEstadoAcademicoViewModel(List<Object> estadoAcademico, Persona alumno)
        {
            EstadoAcademico = estadoAcademico;
            Nombre = alumno.Nombre;
            Apellido = alumno.Apellido;
            Legajo = alumno.Legajo;
            Plan = alumno.Plan.Descripcion;
            Especialidad = alumno.Plan.Especialidad.Descripcion;
        }
    }
}
