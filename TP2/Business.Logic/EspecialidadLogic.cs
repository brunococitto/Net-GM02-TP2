using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadAdapter EspecialidadData { get; set; }
        public EspecialidadLogic()
        {
            EspecialidadData =  new EspecialidadAdapter();
        }
        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }
        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }
        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }
        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
    }
}
