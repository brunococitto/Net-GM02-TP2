using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        private readonly AcademyContext _context;
        // Este bypass es para poder usarlo desde el proyecto UI.Consola sin tener que crear el contexto
        public UsuarioAdapter() { }
        public UsuarioAdapter(AcademyContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = sqlUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["ID"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = drUsuarios["clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de usuarios", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand sqlUsuarios = new SqlCommand("select * from usuarios where ID = @id", sqlConn);
                sqlUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = sqlUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["ID"];
                    usr.NombreUsuario = drUsuarios["nombre_usuario"].ToString();
                    usr.Clave = drUsuarios["clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de usuario", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                usuario.Clave = hashearClave(usuario.Clave);
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @NombreUsuario, clave = @Clave, " +
                    "habilitado = @Habilitado, id_persona = @IDPersona " +
                    "WHERE ID = @ID"
                    , sqlConn);
                sqlSave.Parameters.Add("@ID", SqlDbType.Int).Value = usuario.ID;
                sqlSave.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                sqlSave.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                sqlSave.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                sqlSave.Parameters.Add("@IDPersona", SqlDbType.Int).Value = usuario.IDPersona;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de usuario", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                usuario.Clave = hashearClave(usuario.Clave);
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO usuarios(nombre_usuario, clave, habilitado, id_persona) " +
                    "VALUES (@NombreUsuario, @Clave, @Habilitado, @IDPersona) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                sqlSave.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                sqlSave.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                sqlSave.Parameters.Add("@IDPersona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear usuario", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete usuarios where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar usuario", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
        public Usuario Login(string usuario, string contrasenia)
        {
            try
            {
                contrasenia = hashearClave(contrasenia);
                Usuario usr = new Usuario();
                this.OpenConnection();
                SqlCommand cmdLogin = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@usuario and clave=@contrasenia", sqlConn);
                cmdLogin.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdLogin.Parameters.Add("@contrasenia", SqlDbType.VarChar, 50).Value = contrasenia;
                SqlDataReader drLogin = cmdLogin.ExecuteReader();
                if (drLogin.Read())
                {
                    usr.ID = (int)drLogin["ID"];
                    usr.NombreUsuario = drLogin["nombre_usuario"].ToString();
                    usr.Clave = drLogin["clave"].ToString();
                    usr.Habilitado = (bool)drLogin["habilitado"];
                    usr.IDPersona = (int)drLogin["id_persona"];
                    drLogin.Close();
                    return usr;
                } else
                {
                    return null;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private string hashearClave(string claveOriginal)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var claveHasheada = sha1.ComputeHash(Encoding.UTF8.GetBytes(claveOriginal));
                var salida = new StringBuilder(claveHasheada.Length * 2);
                foreach (byte b in claveHasheada)
                {
                    salida.Append(b.ToString("X2"));
                }
                return salida.ToString();
            }
        }
    }
}
