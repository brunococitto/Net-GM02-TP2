using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
                inscripciones = _context.AlumnoInscripciones.ToList();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripciones", e);
                throw ExceptionManejada;
            }
            return inscripciones;
        }
        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();
            try
            {
                inscripcion = _context.AlumnoInscripciones.Find(ID);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar inscripción", e);
                throw ExceptionManejada;
            }
            return inscripcion;
        }
        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
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
    }
}
