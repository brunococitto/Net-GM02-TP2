using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _anoCalendario;
        private int _cupo;
        private string _descripcion;
        private int _idComision;
        private int _idMateria;
        [Column("anio_calendario")]
        public int AnoCalendario
        {
            get
            {
                return _anoCalendario;
            }
            set
            {
                _anoCalendario = value;
            }
        }
        [Column("cupo")]
        public int Cupo
        {
            get
            {
                return _cupo;
            }
            set
            {
                _cupo = value;
            }
        }
        [Column("desc_curso")]
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
        [Column("id_comision")]
        public int IDComision
        {
            get
            {
                return _idComision;
            }
            set
            {
                _idComision = value;
            }
        }
        [Column("id_materia")]
        public int IDMateria
        {
            get
            {
                return _idMateria;
            }
            set
            {
                _idMateria = value;
            }
        }
    }
}
