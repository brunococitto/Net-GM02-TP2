using System;

namespace UI.Web.Models
{
    public class UsuarioLogeado
    {
        public int Id { get; }
        public string Nombre { get; }
        public string NombreUsuario { get; }
        public Business.Entities.Persona.TiposPersona Role { get; set; }
        public DateTime MomentoCreacion { get; }

        public UsuarioLogeado(int id, string nombre, string nombreUsuario, Business.Entities.Persona.TiposPersona role, DateTime? momentoCreacion = null)
        {
            Id = id;
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            Role = role;
            MomentoCreacion = momentoCreacion ?? DateTime.Now;
        }

        public static UsuarioLogeado MapearUsuario (Business.Entities.Usuario usuario)
        {
            return new UsuarioLogeado(
                id: usuario.ID,
                nombre: $"{usuario.Persona.Nombre} {usuario.Persona.Apellido}",
                nombreUsuario: usuario.NombreUsuario,
                role: usuario.Persona.TipoPersona
                );
        }
    }
}
