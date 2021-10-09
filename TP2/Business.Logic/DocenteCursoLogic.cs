using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter AsignacionData { get; set; }
        public DocenteCursoLogic(DocenteCursoAdapter asignacionAdapter)
        {
            AsignacionData = asignacionAdapter;
        }
        public List<DocenteCurso> GetAll()
        {
            try
            {
                return AsignacionData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar asignaciones", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public List<Object> GetAsignacionesFormateadas()
        {
            try
            {
                return AsignacionData.GetAsignacionesFormateadas();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar asignaciones formateadas", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public DocenteCurso GetOne(int id)
        {
            try
            {
                return AsignacionData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar asignacion", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                AsignacionData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar asignacion", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public List<Curso> GetCursosProfesor(int idProfesor)
        {
            try
            {
                return AsignacionData.GetCursosProfesor(idProfesor);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar cursos para el profesor", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }

        }
        public void Save(DocenteCurso inscripcion)
        {
            AsignacionData.Save(inscripcion);
        }
    }
}
