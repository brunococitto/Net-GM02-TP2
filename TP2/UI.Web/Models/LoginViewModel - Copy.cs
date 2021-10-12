using FluentValidation;

namespace UI.Web.Models
{
    public record LoginViewModel
    {
        public string NombreUsuario { get; init; }
        public string Clave { get; init; }
        public bool IsPersistent { get; init; }
    }

    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(l => l.NombreUsuario).NotEmpty();
            RuleFor(l => l.Clave).NotEmpty();
        }
    }
}