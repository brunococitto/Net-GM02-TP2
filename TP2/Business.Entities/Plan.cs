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
        private string _Descripcion;
        private int _IDEspecialidad;
        [Column("desc_plan")]
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
        [Column("id_especialidad")]
        public int IDEspecialidad
        {
            get
            {
                return _IDEspecialidad;
            }
            set
            {
                _IDEspecialidad = value;
            }
        }
    }
}
