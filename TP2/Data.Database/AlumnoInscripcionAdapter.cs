using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public AlumnoInscripcionAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                inscripciones = _context.AlumnoInscripciones.Include(i => i.Curso).Include(i => i.Persona).ToList();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de inscripciones", e);
                throw ExceptionManejada;
            }
            return inscripciones;
        }
        public Business.Entities.AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();
            try
            {
                inscripcion = _context.AlumnoInscripciones
                    .Include(i => i.Curso)
                    .ThenInclude(c => c.Materia)
                    .Include(i => i.Persona)
                    .FirstOrDefault(i => i.ID == id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de inscripción", e);
                throw ExceptionManejada;
            }
            return inscripcion;
        }
        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                _context.AlumnoInscripciones.Update(inscripcion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de inscripción", e);
                throw ExceptionManejada;
            }
        }
        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                _context.AlumnoInscripciones.Add(inscripcion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear inscripción", e);
                throw ExceptionManejada;
            }
        }
        public void Delete(int ID)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();
            try
            {
                inscripcion = _context.AlumnoInscripciones.Find(ID);
                _context.AlumnoInscripciones.Remove(inscripcion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar inscripción", e);
                throw ExceptionManejada;
            }
        }
        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
        public List<AlumnoInscripcion> GetInscripcionesCurso(int idCurso)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                inscripciones = _context.AlumnoInscripciones.Include(i => i.Persona).Include(i => i.Curso).Where(i => i.IDCurso == idCurso).ToList();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones para el curso seleccionado", e);
                throw ExceptionManejada;
            }
            return inscripciones;
        }
        public List<Object> GetInscripcionesFormateadas()
        {
            try
            {
                var consulta = from insc in GetAll()
                                    select new
                                    {
                                        ID = insc.ID,
                                        Legajo = insc.Persona.Legajo,
                                        Nombre = insc.Persona.Nombre,
                                        Apellido = insc.Persona.Apellido,
                                        Curso = insc.Curso.Descripcion,
                                        Condicion = insc.Condicion,
                                        Nota = insc.Nota
                                    };
                return consulta.ToList<Object>();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones formateadas", e);
                throw ExceptionManejada;
            }            
        }
        public List<Object> GetEstadoAcademico(int idAlumno)
        {
            try
            {
                List<AlumnoInscripcion> inscripciones = _context.AlumnoInscripciones.Include(i => i.Curso).Where(i => i.IDAlumno == idAlumno).ToList();
                var consulta = from insc in inscripciones
                               join m in new MateriaAdapter(_context).GetAll()
                               on insc.Curso.IDMateria equals m.ID
                               select new
                               {
                                   Materia = m.Descripcion,
                                   Condicion = insc.Condicion,
                                   Nota = insc.Nota
                               };
                return consulta.ToList<Object>();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar estado academico de alumno", e);
                throw ExceptionManejada;
            }

        }
        public bool CursoTieneCupo(int idCurso)
        {
            try
            {
                CursoAdapter cursoAdapter = new CursoAdapter(_context);
                Curso curso = cursoAdapter.GetOne(idCurso);
                List<AlumnoInscripcion> inscripciones = GetInscripcionesCurso(idCurso);
                return curso.Cupo > inscripciones.Count;
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al chequear cupo del curso", e);
                throw ExceptionManejada;
            }
        }
    }
}
