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
            return AsignacionData.GetAll();
        }
        public List<Object> GetAsignacionesFormateadas()
        {
            return AsignacionData.GetAsignacionesFormateadas();
        }
        public DocenteCurso GetOne(int id)
        {
            return AsignacionData.GetOne(id);
        }
        public void Delete(int id)
        {
            AsignacionData.Delete(id);
        }
        public void Save(DocenteCurso inscripcion)
        {
            AsignacionData.Save(inscripcion);
        }
    }
}
