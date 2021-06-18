using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Database
{
    public class ModuloAdapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Modulo> _Modulos;

        private static List<Modulo> Modulos
        {
            get
            {
                if (_Modulos == null)
                {
                    _Modulos = new List<Business.Entities.Modulo>();
                    Business.Entities.Modulo mod;

                    mod = new Business.Entities.Modulo();
                    mod.ID = 1;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.Descripcion = "Modulo 1";
                    _Modulos.Add(mod);

                    mod = new Business.Entities.Modulo();
                    mod.ID = 2;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.Descripcion = "Modulo 2";
                    _Modulos.Add(mod);

                    mod = new Business.Entities.Modulo();
                    mod.ID = 3;
                    mod.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mod.Descripcion = "Modulo 3";
                    _Modulos.Add(mod);
                }
                return _Modulos;
            }
        }
        #endregion
        public List<Modulo> GetAll()
        {
            return new List<Modulo>(Modulos);
        }

        public Business.Entities.Modulo GetOne(int ID)
        {
            return Modulos.Find(delegate (Modulo m) { return m.ID == ID; });
        }

        public void Delete(int ID)
        {
            Modulos.Remove(this.GetOne(ID));
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Modulo usr in Modulos)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                modulo.ID = NextID + 1;
                Modulos.Add(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.ID);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                Modulos[Modulos.FindIndex(delegate (Modulo m) { return m.ID == m.ID; })] = modulo;
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
