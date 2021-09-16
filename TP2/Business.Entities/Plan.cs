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
        private Especialidad _especialidad;
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
        [ForeignKey("Especialidad")]
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
        public Especialidad Especialidad
        {
            get
            {
                return _especialidad;
            }
            set
            {
                _especialidad = value;
            }
        }
    }
}
