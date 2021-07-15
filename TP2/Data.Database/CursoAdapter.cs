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
        private Adapter _adapter;
        public CursoAdapter(AcademyContext context)
        {
            _adapter = new Adapter();
            _context = context;
        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
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
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Descripcion = (string)drCursos["desc_curso"];
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
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET desc_curso = @desc, id_materia = @id_mat,id_comision = @id_com ,anio_calendario = @anio_cal,cupo = @cupo " +
                    "WHERE id_curso = @id"
                    , sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_mat", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_com", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_cal", SqlDbType.VarChar, 50).Value = curso.AnoCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO cursos(desc_curso,id_materia,id_comision,anio_calendario, cupo) " +
                    "VALUES (@desc,@id_mat, @id_com, @anio_cal,@cupo) " +
                    "SELECT @@identity"
                    , sqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                cmdSave.Parameters.Add("@id_mat", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_com", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_cal", SqlDbType.VarChar, 50).Value = curso.AnoCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                
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
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
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
