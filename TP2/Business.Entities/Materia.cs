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
        private string _descripcion;
        private int _hsSemanales;
        private int _hsTotales;
        private int _idPlan;
        [Column("desc_materia")]
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
        [Column("hs_semanales")]
        public int HSSemanales
        {
            get
            {
                return _hsSemanales;
            }
            set
            {
                _hsSemanales = value;
            }
        }
        [Column("hs_totales")]
        public int HSTotales
        {
            get
            {
                return _hsTotales;
            }
            set
            {
                _hsTotales = value;
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
