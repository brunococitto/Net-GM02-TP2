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
    public class DocenteCursoAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public DocenteCursoAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> asginaciones = new List<DocenteCurso>();
            try
            {
                asginaciones = _context.DocentesCursos.Include(a => a.Curso).Include(a => a.Persona).ToList();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar asignaciones", e);
                throw ExceptionManejada;
            }
            return asginaciones;
        }
        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso asignacion = new DocenteCurso();
            try
            {
                asignacion = _context.DocentesCursos.Find(ID);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de asignación", e);
                throw ExceptionManejada;
            }
            return asignacion;
        }
        protected void Update()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de asignación", e);
                throw ExceptionManejada;
            }
        }
        protected void Insert(DocenteCurso asignacion)
        {
            try
            {
                _context.DocentesCursos.Add(asignacion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear asginación", e);
                throw ExceptionManejada;
            }
        }
        public void Delete(int ID)
        {
            DocenteCurso asignacion = new DocenteCurso();
            try
            {
                asignacion = _context.DocentesCursos.Find(ID);
                _context.DocentesCursos.Remove(asignacion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar asignación", e);
                throw ExceptionManejada;
            }
        }
        public void Save(DocenteCurso asignacion)
        {
            if (asignacion.State == BusinessEntity.States.New)
            {
                this.Insert(asignacion);
            }
            else if (asignacion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(asignacion.ID);
            }
            else if (asignacion.State == BusinessEntity.States.Modified)
            {
                this.Update();
            }
            asignacion.State = BusinessEntity.States.Unmodified;
        }
        public List<Object> GetAsignacionesFormateadas()
        {
            try
            {
                var consulta = from asc in GetAll()
                               select new
                                    {
                                        ID = asc.ID,
                                        Legajo = asc.Persona.Legajo,
                                        Nombre = asc.Persona.Nombre,
                                        Apellido = asc.Persona.Apellido,
                                        Curso = asc.Curso.Descripcion,
                                        Cargo = asc.Cargo
                                    };
                return consulta.ToList<Object>();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar asignaciones formateadas", e);
                throw ExceptionManejada;
            }            
        }
    }
}
