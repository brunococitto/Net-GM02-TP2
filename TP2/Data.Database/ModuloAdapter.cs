using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public ModuloAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlModulos = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drModulos = sqlModulos.ExecuteReader();
                while (drModulos.Read())
                {
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulos["ID"];
                    mod.Descripcion = drModulos["desc_modulo"].ToString();
                    modulos.Add(mod);
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de modulos", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }

        public Business.Entities.Modulo GetOne(int ID)
        {
            Modulo mod = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand sqlModulos = new SqlCommand("select * from modulos where ID = @id", sqlConn);
                sqlModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = sqlModulos.ExecuteReader();
                if (drModulos.Read())
                {
                    mod.ID = (int)drModulos["ID"];
                    mod.Descripcion = drModulos["desc_modulo"].ToString();
                }
                drModulos.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de modulo", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mod;
        }

        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE modulos SET desc_modulo = @desc_modulo " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                sqlSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de modulo", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO modulos(desc_modulo) " +
                    "VALUES (@desc_modulo) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                modulo.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());

            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear modulo", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Modulo mod = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete modulos where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar modulo", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.New)
            {
                this.Insert(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                this.Update(modulo);
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
