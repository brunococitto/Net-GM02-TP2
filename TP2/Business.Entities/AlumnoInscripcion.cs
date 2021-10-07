using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _condicion;
        private int _idAlumno;
        private int _idCurso;
        private int _nota;
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
        public string Condicion
        {
            get
            {
                return _condicion;
            }
            set
            {
                _condicion = value;
            }
        }
        
        [ForeignKey("Persona")]
        public int IDAlumno
        {
            get
            {
                return _idAlumno;
            }
            set
            {
                _idAlumno = value;
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
        public int Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
            }
        }
    }
}
