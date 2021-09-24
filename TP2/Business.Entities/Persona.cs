using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        public enum TiposPersona
        {
            Alumno = 1,
            Profesor = 2,
            Administrativo = 3
        }
        private string _apellido;
        private string _nombre;
        private string _direccion;
        private string _email;
        private string _telefono;
        private int? _idPlan;
        private int _legajo;
        [DataType(DataType.Date)]
        private DateTime _fechaNacimiento;
        public TiposPersona _tipoPersona;
        private Plan? _plan;
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }
        [ForeignKey("Plan")]
        public int? IDPlan
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
        public int Legajo
        {
            get
            {
                return _legajo;
            }
            set
            {
                _legajo = value;
            }
        }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }
        public TiposPersona TipoPersona
        {
            get
            {
                return _tipoPersona;
            }
            set
            {
                _tipoPersona = value;
            }
        }
        public Plan? Plan
        {
            get
            {
                return _plan ?? new Plan();
            }
            set
            {
                _plan = value;
            }
        }
    }
}
