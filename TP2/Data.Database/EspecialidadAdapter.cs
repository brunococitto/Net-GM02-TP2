using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Especialidad> _Especialidades;

        private static List<Especialidad> Especialidades
        {
            get
            {
                if (_Especialidades == null)
                {
                    _Especialidades = new List<Business.Entities.Especialidad>();
                    Business.Entities.Especialidad esp;

                    esp = new Business.Entities.Especialidad();
                    esp.ID = 1;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "Sistemas";
                    _Especialidades.Add(esp);

                    esp = new Business.Entities.Especialidad();
                    esp.ID = 2;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "Mecánica";
                    _Especialidades.Add(esp);

                    esp = new Business.Entities.Especialidad();
                    esp.ID = 3;
                    esp.State = Business.Entities.BusinessEntity.States.Unmodified;
                    esp.Descripcion = "Civil";
                    _Especialidades.Add(esp);
                }
                return _Especialidades;
            }
        }
        #endregion

        public List<Especialidad> GetAll()
        {
            return new List<Especialidad>(Especialidades);
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            return Especialidades.Find(delegate (Especialidad e) { return e.ID == ID; });
        }

        public void Delete(int ID)
        {
            Especialidades.Remove(this.GetOne(ID));
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Especialidad usr in Especialidades)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                especialidad.ID = NextID + 1;
                Especialidades.Add(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                Especialidades[Especialidades.FindIndex(delegate (Especialidad e) { return e.ID == e.ID; })] = especialidad;
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
