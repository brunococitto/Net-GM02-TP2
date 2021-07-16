using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _AnoEspecialidad;
        private string _Descripcion;
        private int _IDPlan;
        [Column("anio_especialidad")]
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
        [Column("desc_comision")]
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
        [Column("id_plan")]
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
