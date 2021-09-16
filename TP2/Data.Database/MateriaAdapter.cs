using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public MateriaAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlMaterias = new SqlCommand(
                    "select * from materias as M join planes as P on M.id_plan = P.ID join especialidades as E on P.id_especialidad = E.ID"
                    , sqlConn);
                SqlDataReader drMaterias = sqlMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia materia = new Materia();
                    materia.ID = (int)drMaterias["ID"];
                    materia.Descripcion = drMaterias["desc_materia"].ToString();
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materia.Plan = new Plan()
                    {
                        Descripcion = drMaterias["desc_plan"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            Descripcion = drMaterias["desc_especialidad"].ToString(),
                        }
                    };
                    materias.Add(materia);
                }
                drMaterias.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de materias", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand sqlMaterias = new SqlCommand(
                    "select * from materias as M join planes as P on M.id_plan = P.ID join especialidades as E on P.id_especialidad = E.ID where M.ID = @id"
                    , sqlConn);
                sqlMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = sqlMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    materia.ID = (int)drMaterias["ID"];
                    materia.Descripcion = drMaterias["desc_materia"].ToString();
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materia.Plan = new Plan()
                    {
                        Descripcion = drMaterias["desc_plan"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            Descripcion = drMaterias["desc_especialidad"].ToString(),
                        }
                    };
                }
                drMaterias.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de la materia", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE materias SET desc_materia = @desc, hs_semanales = @hs_sem, " +
                    "hs_totales = @hs_tot, id_plan = @id_plan " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                sqlSave.Parameters.Add("@hs_sem", SqlDbType.VarChar, 50).Value = materia.HSSemanales;
                sqlSave.Parameters.Add("@hs_tot", SqlDbType.VarChar, 50).Value = materia.HSTotales;
                sqlSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = materia.IDPlan;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de la materia", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "VALUES (@desc, @hs_sem, @hs_tot, @id_plan) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                sqlSave.Parameters.Add("@hs_sem", SqlDbType.VarChar, 50).Value = materia.HSSemanales;
                sqlSave.Parameters.Add("@hs_tot", SqlDbType.VarChar, 50).Value = materia.HSTotales;
                sqlSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear materia", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete materias where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar materia", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
