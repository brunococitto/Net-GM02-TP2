using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    class Singleton
    {
        private Singleton() { }
        private Persona _personaActual;
        private Usuario _usuarioActual;
        private System.Windows.Forms.DataGridView _dgvActual;
        private string _moduloActual;
        private static Singleton _instance;
        public static Singleton getInstance()
        {
            return _instance;
        }
        public static void setInstance(Persona per, Usuario usr)
        {
            _instance = new Singleton();
            _instance._personaActual = per;
            _instance._usuarioActual = usr;
        }
        public Persona PersonaLogged
        {
            get
            {
                return _personaActual;
            }
        }
        public Usuario UserLogged
        {
            get
            {
                return _usuarioActual;
            }
        }
        public System.Windows.Forms.DataGridView DgvActual
        {
            get
            {
                return _dgvActual;
            }
            set
            {
                _dgvActual = value;
            }
        }
        public string ModuloActual
        {
            get
            {
                return _moduloActual;
            }
            set
            {
                _moduloActual = value;
            }
        }
    }
}
