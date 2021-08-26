using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter ModuloData { get; set; }
        public ModuloLogic(ModuloAdapter moduloAdapter)
        {
            ModuloData = moduloAdapter;
        }
        public List<Modulo> GetAll()
        {
            try
            {
                return ModuloData.GetAll();
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de modulos", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public Modulo GetOne(int id)
        {
            try
            {
                return ModuloData.GetOne(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar datos del modulo", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                ModuloData.Delete(id);
            }
            catch (Exception e)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar modulo", e);
                Logger.Log(ExceptionManejada.Message);
                throw ExceptionManejada;
            }
        }
        public void Save(Modulo modulo)
        {
            ModuloData.Save(modulo);
        }
    }
}
