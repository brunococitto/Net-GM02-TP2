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
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;
        private int _IDPersona;
        [Column("nombre_usuario")]
        public string NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }
            set
            {
                _NombreUsuario = value;
            }
        }
        [Column("clave")]
        public string Clave
        {
            get
            {
                return _Clave;
            }
            set
            {
                _Clave = value;
            }
        }
        [Column("habilitado")]
        public bool Habilitado
        {
            get
            {
                return _Habilitado;
            }
            set
            {
                _Habilitado = value;
            }
        }
        [Column("id_persona")]
        public int IDPersona
        {
            get
            {
                return _IDPersona;
            }
            set
            {
                _IDPersona = value;
            }
        }
    }
}
