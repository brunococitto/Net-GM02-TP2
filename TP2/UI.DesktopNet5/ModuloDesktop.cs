using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        public ModuloDesktop()
        {
            InitializeComponent();
        }
        public ModuloDesktop(ModoForm modo) : this()
        {
            Modos = modo;
        }
        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            Modos = modo;
            ModuloLogic m = new ModuloLogic();
            ModuloActual = m.GetOne(ID);
            MapearDeDatos();
        }
        public Modulo ModuloActual { set; get; }
        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.ModuloActual.Descripcion;
            switch (this.Modos)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {

            if (Modos == ModoForm.Alta)
            {
                ModuloActual = new Modulo();
                ModuloActual.Descripcion = this.txtDescripcion.Text;
            }
            if (Modos == ModoForm.Modificacion)
            {
                ModuloActual.Descripcion = this.txtDescripcion.Text;
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    ModuloActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ModuloActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            ModuloLogic m = new ModuloLogic();
            MapearADatos();
            m.Save(ModuloActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modos)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Baja:
                    Eliminar();
                    Close();
                    break;
                case ModoForm.Consulta:
                    Close();
                    break;

            }
        }
        public virtual void Eliminar()
        {
            ModuloLogic m = new ModuloLogic();
            m.Delete(ModuloActual.ID);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtDescripcion.Text))
            {
                Notificar("Error", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else { return true; }
        }
    }
}

