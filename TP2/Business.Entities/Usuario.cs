using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        private int _idPersona;
        private Persona _persona;
        [Column("nombre_usuario")]
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }
        [Column("clave")]
        public string Clave
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave = value;
            }
        }
        [Column("habilitado")]
        public bool Habilitado
        {
            get
            {
                return _habilitado;
            }
            set
            {
                _habilitado = value;
            }
        }
        [Column("id_persona")]
        [ForeignKey("Persona")]
        public int IDPersona
        {
            get
            {
                return _idPersona;
            }
            set
            {
                _idPersona = value;
            }
        }
        public Persona Persona
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
            }
        }
        public string Salt { get; set; }
    }
}
