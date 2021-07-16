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
        private int _AnoCalendario;
        private int _Cupo;
        private string _Descripcion;
        private int _IDComision;
        private int _IDMateria;
        [Column("anio_calendario")]
        public int AnoCalendario
        {
            get
            {
                return _AnoCalendario;
            }
            set
            {
                _AnoCalendario = value;
            }
        }
        [Column("cupo")]
        public int Cupo
        {
            get
            {
                return _Cupo;
            }
            set
            {
                _Cupo = value;
            }
        }
        [Column("desc_curso")]
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
        [Column("id_comision")]
        public int IDComision
        {
            get
            {
                return _IDComision;
            }
            set
            {
                _IDComision = value;
            }
        }
        [Column("id_materia")]
        public int IDMateria
        {
            get
            {
                return _IDMateria;
            }
            set
            {
                _IDMateria = value;
            }
        }
    }
}
