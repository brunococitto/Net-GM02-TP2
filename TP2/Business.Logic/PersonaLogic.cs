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
            return PersonaData.GetAll();
        }
        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }
        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }
        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }
    }
}
