using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public ComisionAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlComisiones = new SqlCommand(
                    "select * from comisiones as C join planes as P on C.id_plan = P.ID " +
                    "join especialidades as E on P.id_especialidad = E.ID"
                    , sqlConn);
                SqlDataReader drComisiones = sqlComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comi = new Comision();
                    comi.ID = (int)drComisiones["ID"];
                    comi.Descripcion = drComisiones["desc_comision"].ToString();
                    comi.AnoEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                    comi.Plan = new Plan()
                    {
                        Descripcion = drComisiones["desc_plan"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            Descripcion = drComisiones["desc_especialidad"].ToString(),
                        }
                    };
                    comisiones.Add(comi);
                    
                }
                drComisiones.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de comisiones", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            try
            {
                Comision comi = new Comision();
                this.OpenConnection();
                SqlCommand sqlComisiones = new SqlCommand(
                    "select * from comisiones as C join planes as P on C.id_plan = P.ID " +
                    "join especialidades as E on P.id_especialidad = E.ID where C.ID = @id"
                    , sqlConn);
                sqlComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = sqlComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comi.ID = (int)drComisiones["ID"];
                    comi.Descripcion = drComisiones["desc_comision"].ToString();
                    comi.AnoEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                    comi.Plan = new Plan()
                    {
                        Descripcion = drComisiones["desc_plan"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            Descripcion = drComisiones["desc_especialidad"].ToString(),
                        }
                    };
                }
                drComisiones.Close();
                return comi;
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de la comision", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad, " +
                    "id_plan = @id_plan " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                sqlSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                sqlSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnoEspecialidad;
                sqlSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la comision", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) " +
                    "VALUES (@desc_comision, @anio_especialidad, @id_plan) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                sqlSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnoEspecialidad;
                sqlSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear la comision", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Comision comi = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete comisiones where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar la comision", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
