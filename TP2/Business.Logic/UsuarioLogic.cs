using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter UsuarioData { get; set; }
        public UsuarioLogic(UsuarioAdapter usuarioAdapter)
        {
            UsuarioData =  usuarioAdapter;
        }
        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de usuarios", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Usuario GetOne(int id)
        {
            try
            {
                return UsuarioData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de usuario", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                UsuarioData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar usuario", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
        public Usuario Login(string usuario, string contrasenia)
        {
            Usuario usr = UsuarioData.Login(usuario, contrasenia);
            return usr;
        }
    }
}
