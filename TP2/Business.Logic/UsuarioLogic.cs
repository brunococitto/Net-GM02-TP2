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
            return UsuarioData.GetAll();
        }
        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }
        public void Delete(int id)
        {
            UsuarioData.Delete(id);
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
