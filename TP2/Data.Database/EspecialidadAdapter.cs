using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public EspecialidadAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlEspecialidades = new SqlCommand("select * from especialidades", sqlConn);
                SqlDataReader drEspecialidades = sqlEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["ID"];
                    esp.Descripcion = drEspecialidades["desc_especialidad"].ToString();
                    especialidades.Add(esp);
                }
                drEspecialidades.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de especialidades", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand sqlEspecialidades = new SqlCommand("select * from especialidades where ID = @id", sqlConn);
                sqlEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = sqlEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["ID"];
                    esp.Descripcion = drEspecialidades["desc_especialidad"].ToString();
                }
                drEspecialidades.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de especialidad", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }

        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                sqlSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de especialidad", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO especialidades(desc_especialidad) " +
                    "VALUES (@desc_especialidad) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());

            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear especialidad", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete especialidades where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar especialidad", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
