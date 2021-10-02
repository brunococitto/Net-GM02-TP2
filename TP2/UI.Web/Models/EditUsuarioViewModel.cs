using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class EditUsuarioViewModel
    {   
        public Persona Persona { get; }
        public Usuario Usuario { get; }
        
        public EditUsuarioViewModel(Usuario usuario)
        {
            Usuario = usuario;
            Persona = usuario.Persona;
        }
    }
}
