using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TiposCargo
        {
            // Preguntar esto
            Auxiliar,
            Suplente
        }
        private TiposCargo _cargo;
        private int _idCurso;
        private int _idDocente;
        private Persona _persona;
        private Curso _curso;
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
        public Curso Curso
        {
            get
            {
                return _curso;
            }
            set
            {
                _curso = value;
            }
        }
        public TiposCargo Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
            }
        }
        [ForeignKey("Curso")]
        public int IDCurso
        {
            get
            {
                return _idCurso;
            }
            set
            {
                _idCurso = value;
            }
        }
        [ForeignKey("Persona")]
        public int IDDocente
        {
            get
            {
                return _idDocente;
            }
            set
            {
                _idDocente = value;
            }
        }
    }
}
