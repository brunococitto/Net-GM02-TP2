using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _AnoEspecialidad;
        private string _Descripcion;
        private int _IDPlan;
        public int AnoEspecialidad
        {
            get
            {
                return _AnoEspecialidad;
            }
            set
            {
                _AnoEspecialidad = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }
        public int IDPlan
        {
            get
            {
                return _IDPlan;
            }
            set
            {
                _IDPlan = value;
            }
        }
    }
}
