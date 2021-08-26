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
        private EspecialidadAdapter EspecialidadData { get; set; }
        public EspecialidadLogic(EspecialidadAdapter especialidadAdapter)
        {
            EspecialidadData = especialidadAdapter;
        }
        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de especialidades", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Especialidad GetOne(int id)
        {
            try
            {
                return EspecialidadData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de especialidad", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                EspecialidadData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar especialidad", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
    }
}
