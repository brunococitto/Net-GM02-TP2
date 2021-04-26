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
        private TiposCargo _Cargo;
        private int _IDCurso;
        private int _IDDocente;
        public TiposCargo Cargo
        {
            get
            {
                return _Cargo;
            }
            set
            {
                _Cargo = value;
            }
        }
        public int IDCurso
        {
            get
            {
                return _IDCurso;
            }
            set
            {
                _IDCurso = value;
            }
        }
        public int IDDocente
        {
            get
            {
                return _IDDocente;
            }
            set
            {
                _IDDocente = value;
            }
        }
    }
}
