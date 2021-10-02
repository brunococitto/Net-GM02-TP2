using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Web.Models
{
    public class CreateUsuarioViewModel
    {
        public Usuario? Usuario { get; }
        public List<SelectListItem> Personas { get; }
        public CreateUsuarioViewModel(Usuario? usuario, IEnumerable<Persona> personas)
        {
            Usuario = usuario;
        }
    }
}
