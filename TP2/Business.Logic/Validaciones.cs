using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using Business.Entities;


namespace Business.Logic
{
    public class Validaciones
    {
        static public void ValidarEmail(string email)
        {
            try
            {
                if (!(email.Contains("@") & email.Contains(".")))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Formato de email erroneo", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarNulo(string campo, string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(campo))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe completarse", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarClave(string clave)
        {
            try
            {
                if (clave.Length < 8)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"La clave debe tener mas de 8 caracteres", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarConfirmacionClave(string clave, string clave2)
        {
            try
            {
                if (clave != clave2)
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"La claves ingresadas no coinciden ", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarNumero(string campo, string tipo)
        {
            Regex regex = new Regex("^[0-9]+$");
            try
            {
                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe ser numerico", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarLetras(string campo, string tipo)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            try
            {

                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} contener solo letras", e);
                throw ExceptionManejada;
            }
        }
        static public void ValidarLetrasNumeros(string campo, string tipo)
        {
            Regex regex = new Regex("^[a-zA-Z 1-9]+$");
            try
            {
                if (!(regex.IsMatch(campo)))
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception($"El campo {tipo} debe contener solo caracteres alfanuméricos", e);
                throw ExceptionManejada;
            }
        }
    }
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.NombreUsuario).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9]+$").WithMessage("'Nombre' debe contener solo letras y/o números"); // ValidarLetrasNumeros
            RuleFor(x => x.Clave).NotNull().MinimumLength(8);
        }

    }
    public class PersonaValidator : AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z ]+$").WithMessage("'Nombre' debe contener solo letras"); // ValidarLetras
            RuleFor(x => x.Apellido).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z ]+$").WithMessage("'Apellido' debe contener solo letras"); // ValidarLetras
            RuleFor(x => x.Direccion).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Dirección' debe contener solo letras y/o números"); // ValidarLetrasNumeros
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Legajo).NotNull();
            RuleFor(x => x.Telefono).NotEmpty().Matches("^[0-9]+$").WithMessage("'Teléfono' debe contener solo números");
        }
    }
    public class PlanValidator : AbstractValidator<Plan>
    {
        public PlanValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Descripcion' debe contener solo letras y/o números"); // ValidarLetrasNumeros
        }
    }
    public class MateriaValidator : AbstractValidator<Materia>
    {
        public MateriaValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().Length(min: 3, max: 20).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Descripcion' debe contener solo letras y/o números"); // ValidarLetrasNumeros
            RuleFor(x => x.HSSemanales).NotEmpty().InclusiveBetween(from: 2, to: 6);
            RuleFor(x => x.HSTotales).NotEmpty().InclusiveBetween(from: 90, to: 150);
            RuleFor(x => x.IDPlan).NotEmpty();
        }
    }
    public class EspecialidadValidator : AbstractValidator<Especialidad>
    {
        public EspecialidadValidator()
        {
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Descripcion' debe contener solo letras y/o números"); // ValidarLetrasNumeros
        }
    }
    public class DocenteCursoValidator : AbstractValidator<DocenteCurso>
    {
        public DocenteCursoValidator()
        {
            RuleFor(x => x.IDDocente).NotNull();
            RuleFor(x => x.IDCurso).NotNull();
        }
    }
    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.AnoCalendario).NotEmpty().GreaterThan(2000);
            RuleFor(x => x.Cupo).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Descripcion' debe contener solo letras y/o números"); // ValidarLetrasNumeros
            RuleFor(x => x.IDComision).NotNull();
            RuleFor(x => x.IDMateria).NotNull();
        }
    }
    public class ComisionValidator : AbstractValidator<Comision>
    {
        public ComisionValidator()
        {
            RuleFor(x => x.AnoEspecialidad).NotNull().GreaterThan(0);
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9 ]+$").WithMessage("'Descripcion' debe contener solo letras y/o números"); // ValidarLetrasNumeros
        }
    }
    public class AlumnoInscripcionValidator : AbstractValidator<AlumnoInscripcion>
    {
        public AlumnoInscripcionValidator()
        {
            RuleFor(x => x.IDAlumno).NotNull();
            RuleFor(x => x.IDCurso).NotNull();
        }
    }
}