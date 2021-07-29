using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
