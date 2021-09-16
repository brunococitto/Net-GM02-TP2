using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _anoEspecialidad;
        private string _descripcion;
        private int _idPlan;
        [Column("anio_especialidad")]
        [Display(Name = "Año especialidad")]
        public int AnoEspecialidad
        {
            get
            {
                return _anoEspecialidad;
            }
            set
            {
                _anoEspecialidad = value;
            }
        }
        [Column("desc_comision")]
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }
        [Column("id_plan")]
        public int IDPlan
        {
            get
            {
                return _idPlan;
            }
            set
            {
                _idPlan = value;
            }
        }
    }
}
