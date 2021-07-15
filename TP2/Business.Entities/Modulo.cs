using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string _Descripcion;
        [Column("desc_modulo")]
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
    }
}
