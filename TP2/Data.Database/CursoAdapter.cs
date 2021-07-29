using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public CursoAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand sqlCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = sqlCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["ID"];
                    curso.Descripcion = drCursos["desc_curso"].ToString();
                    curso.AnoCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    cursos.Add(curso);
                }
                drCursos.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de cursos", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand sqlCursos = new SqlCommand("select * from cursos where ID = @id", sqlConn);
                sqlCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = sqlCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["ID"];
                    curso.Descripcion = drCursos["desc_curso"].ToString();
                    curso.AnoCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                }
                drCursos.Close();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de curso", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        protected void Update(Curso curso)
        {
            try
            {
                //En UPDATE poner desc en caso de considerarla
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "UPDATE cursos SET desc_curso = @desc, id_materia = @id_mat,id_comision = @id_com ,anio_calendario = @anio_cal,cupo = @cupo " +
                    "WHERE ID = @id"
                    , sqlConn);
                sqlSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                sqlSave.Parameters.Add("@id_mat", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                sqlSave.Parameters.Add("@id_com", SqlDbType.VarChar, 50).Value = curso.IDComision;
                sqlSave.Parameters.Add("@anio_cal", SqlDbType.VarChar, 50).Value = curso.AnoCalendario;
                sqlSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                sqlSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de curso", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlSave = new SqlCommand(
                    "INSERT INTO cursos(desc_curso,id_materia,id_comision,anio_calendario, cupo) " +
                    "VALUES (@desc,@id_mat, @id_com, @anio_cal,@cupo) " +
                    "SELECT @@identity"
                    , sqlConn);
                sqlSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                sqlSave.Parameters.Add("@id_mat", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                sqlSave.Parameters.Add("@id_com", SqlDbType.VarChar, 50).Value = curso.IDComision;
                sqlSave.Parameters.Add("@anio_cal", SqlDbType.VarChar, 50).Value = curso.AnoCalendario;
                sqlSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)sqlSave.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear curso", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand sqlDelete = new SqlCommand("delete cursos where ID = @id", sqlConn);
                sqlDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                sqlDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar curso", e);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
