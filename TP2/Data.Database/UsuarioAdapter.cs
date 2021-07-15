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
        private Adapter _adapter;
        public UsuarioAdapter(AcademyContext context)
        {
            _adapter = new Adapter();
            _context = context;
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["ID"];
                    usr.NombreUsuario = (string)drUsuarios["NombreUsuario"];
                    usr.Clave = drUsuarios["Clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["Habilitado"];
                    usr.Nombre = drUsuarios["Nombre"].ToString();
                    usr.Apellido = drUsuarios["Apellido"].ToString();
                    usr.Email = drUsuarios["Email"].ToString();
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de usuarios", e);
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
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where ID = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["ID"];
                    usr.NombreUsuario = drUsuarios["NombreUsuario"].ToString();
                    usr.Clave = drUsuarios["Clave"].ToString();
                    usr.Habilitado = (bool)drUsuarios["Habilitado"];
                    usr.Nombre = drUsuarios["Nombre"].ToString();
                    usr.Apellido = drUsuarios["Apellido"].ToString();
                    usr.Email = drUsuarios["Email"].ToString();
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
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET NombreUsuario = @NombreUsuario, Clave = @Clave, " +
                    "Habilitado = @Habilitado, Nombre = @Nombre, Apellido = @Apellido, Email = @Email " +
                    "WHERE ID = @ID"
                    , sqlConn);
                cmdSave.Parameters.Add("@ID", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios(NombreUsuario, Clave, Habilitado, Nombre, Apellido, Email, State) " +
                    "VALUES (@NombreUsuario, @Clave, @Habilitado, @Nombre, @Apellido, @Email, @Estado) " +
                    "SELECT @@identity"
                    , sqlConn);
                cmdSave.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@Estado", SqlDbType.Int).Value = ((int)usuario.State);
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where ID = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
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
                SqlCommand cmdLogin = new SqlCommand("SELECT * FROM usuarios WHERE NombreUsuario=@usuario and Clave=@contrasenia", sqlConn);
                cmdLogin.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdLogin.Parameters.Add("@contrasenia", SqlDbType.VarChar, 50).Value = contrasenia;
                SqlDataReader drLogin = cmdLogin.ExecuteReader();
                if (drLogin.Read())
                {
                    usr.ID = (int)drLogin["ID"];
                    usr.NombreUsuario = drLogin["NombreUsuario"].ToString();
                    usr.Clave = drLogin["Clave"].ToString();
                    usr.Habilitado = (bool)drLogin["Habilitado"];
                    usr.Nombre = drLogin["Nombre"].ToString();
                    usr.Apellido = drLogin["Apellido"].ToString();
                    usr.Email = drLogin["Email"].ToString();
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
