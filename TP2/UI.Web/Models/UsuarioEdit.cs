using System;
using FluentValidation;

namespace UI.Web.Models
{
    public class UsuarioEdit
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public int IDPersona { get; set; }
        public Business.Entities.Persona Persona { get; set; }
        public string Salt { get; set; }
    }
    public class UsuarioEditValidator : AbstractValidator<UsuarioEdit>
    {
        public UsuarioEditValidator()
        {
            RuleFor(x => x.NombreUsuario).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9ñÑ]+$").WithMessage("'Nombre' debe contener solo letras y/o números");
            RuleFor(x => x.Clave).MinimumLength(8).When(x => x.Clave != null);
        }
    }
}
