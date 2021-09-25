using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter InscripcionData { get; set; }
        public AlumnoInscripcionLogic(AlumnoInscripcionAdapter inscrpcionAdapter)
        {
            InscripcionData = inscrpcionAdapter;
        }
        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return InscripcionData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public List<AlumnoInscripcion> GetInscripcionesCurso(int idCurso)
        {
            try
            {
                return InscripcionData.GetInscripcionesCurso(idCurso);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones para el curso seleccionado", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public List<Object> GetInscripcionesFormateadas()
        {
            try
            {
                return InscripcionData.GetInscripcionesFormateadas();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones formateadas", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public List<Object> GetEstadoAcademico(int idAlumno)
        {
            try
            {
                return InscripcionData.GetEstadoAcademico(idAlumno);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar estado academico del alumno", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public AlumnoInscripcion GetOne(int id)
        {
            try
            {
                return InscripcionData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripción", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                InscripcionData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar inscripción", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(AlumnoInscripcion inscripcion)
        {
            try
            {
                if (inscripcion.State == BusinessEntity.States.New & !InscripcionData.CursoTieneCupo(inscripcion.IDCurso))
                {
                    throw new Exception();
                }
                InscripcionData.Save(inscripcion);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("El curso no tiene cupo o se produjo un error", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
    }
}
