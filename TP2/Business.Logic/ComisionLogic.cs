using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter ComisionData { get; set; }
        public ComisionLogic(ComisionAdapter comisionAdapter)
        {
            ComisionData = comisionAdapter;
        }
        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }
        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }
        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }
        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }
    }
}
