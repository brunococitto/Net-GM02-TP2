using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        private readonly AcademyContext _context;
        public PersonaAdapter(AcademyContext context)
        {
            _context = context;
        }
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = _context.Personas.ToList();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de personas", e);
                throw ExceptionManejada;
            }
            return personas;
        }
        public Business.Entities.Persona GetOne(int ID)
        {
            Persona persona = new Persona();
            try
            {
                persona = _context.Personas.Find(ID);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de persona", e);
                throw ExceptionManejada;
            }
            return persona;
        }
        protected void Update(Persona persona)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al modificar datos de persona", e);
                throw ExceptionManejada;
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al crear persona", e);
                throw ExceptionManejada;
            }
        }
        public void Delete(int ID)
        {
            Persona persona = new Persona();
            try
            {
                persona = _context.Personas.Find(ID);
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar persona", e);
                throw ExceptionManejada;
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}