using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter PersonaData { get; set; }
        public PersonaLogic(PersonaAdapter personaAdapter)
        {
            PersonaData =  personaAdapter;
        }
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de personas", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Persona GetOne(int id)
        {
            try
            {
                return PersonaData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de persona", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Persona GetOneConLegajo(int legajo)
        {
            try
            {
                return PersonaData.GetOneConLegajo(legajo);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de persona", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                PersonaData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar persona", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }
    }
}
