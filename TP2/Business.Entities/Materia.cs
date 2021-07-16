using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private int _IDPlan;
        [Column("desc_materia")]
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
        [Column("hs_semanales")]
        public int HSSemanales
        {
            get
            {
                return _HSSemanales;
            }
            set
            {
                _HSSemanales = value;
            }
        }
        [Column("hs_totales")]
        public int HSTotales
        {
            get
            {
                return _HSTotales;
            }
            set
            {
                _HSTotales = value;
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
