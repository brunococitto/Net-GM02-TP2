using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public PlanAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlPlanes = new SqlCommand("" +
                    "select * from planes as P join especialidades as E on P.id_especialidad = E.ID"
                    , sqlConn);
                SqlDataReader drPlanes = sqlPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["ID"];
                    plan.Descripcion = drPlanes["desc_plan"].ToString();
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Especialidad = new Especialidad()
                    {
                        Descripcion = drPlanes["desc_especialidad"].ToString(),
                    };
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de planes", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            try
            {
                Plan plan = new Plan();
                this.OpenConnection();
                SqlCommand sqlPlanes = new SqlCommand(
                    "select * from planes as P join especialidades as E on P.id_especialidad = E.ID where P.ID = @id"
                    , sqlConn);
                sqlPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = sqlPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["ID"];
                    plan.Descripcion = drPlanes["desc_plan"].ToString();
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Especialidad = new Especialidad()
                    {
                        Descripcion = drPlanes["desc_especialidad"].ToString(),
                    };
                }
                drPlanes.Close();
                return plan;
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de plan", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE planes SET desc_plan = @desc, id_especialidad = @id_esp " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                sqlSave.Parameters.Add("@id_esp", SqlDbType.VarChar, 50).Value = plan.IDEspecialidad;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de plan", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO planes(desc_plan, id_especialidad) " +
                    "VALUES (@desc, @id_esp) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                sqlSave.Parameters.Add("@id_esp", SqlDbType.VarChar, 50).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear plan", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete planes where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar plan", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
