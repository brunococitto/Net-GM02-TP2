using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _descripcion;
        private int _idEspecialidad;
        [Column("desc_plan")]
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
        [Column("id_especialidad")]
        public int IDEspecialidad
        {
            get
            {
                return _idEspecialidad;
            }
            set
            {
                _idEspecialidad = value;
            }
        }
    }
}
