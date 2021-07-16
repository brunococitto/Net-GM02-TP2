using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID;
        private States _State;
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
        public int ID
        {
            get
            { 
                return _ID; 
            }
            set
            { 
                _ID = value;
            }
        }
        [NotMapped]
        public States State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
    }
}
