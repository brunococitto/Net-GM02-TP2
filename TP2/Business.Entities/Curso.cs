using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _anoCalendario;
        private int _cupo;
        private string _descripcion;
        private int _idComision;
        private int _idMateria;
        private Comision _comision;
        private Materia _materia;
        [Column("anio_calendario")]
        [Display(Name = "Año calendario")]
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
        [ForeignKey("Comision")]
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
        [ForeignKey("Materia")]
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
        public Comision Comision
        {
            get
            {
                return _comision;
            }
            set
            {
                _comision = value;
            }
        }
        public Materia Materia
        {
            get
            {
                return _materia;
            }
            set
            {
                _materia = value;
            }
        }
    }
}
