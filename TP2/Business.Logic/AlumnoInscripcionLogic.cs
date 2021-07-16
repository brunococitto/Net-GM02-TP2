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
            return InscripcionData.GetAll();
        }
        public AlumnoInscripcion GetOne(int id)
        {
            return InscripcionData.GetOne(id);
        }
        public void Delete(int id)
        {
            InscripcionData.Delete(id);
        }
        public void Save(AlumnoInscripcion inscripcion)
        {
            InscripcionData.Save(inscripcion);
        }
    }
}
