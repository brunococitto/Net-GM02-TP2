using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter PlanData { get; set; }
        public PlanLogic(PlanAdapter planAdapter)
        {
            PlanData = planAdapter;
        }
        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar listado de planes", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Plan GetOne(int id)
        {
            try
            {
                return PlanData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos de plan", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                PlanData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar plan", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
