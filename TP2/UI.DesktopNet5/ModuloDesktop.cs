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
using Data.Database;

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        private readonly ModuloLogic _moduloLogic;
        public ModuloDesktop(AcademyContext context)
        {
            InitializeComponent();
            _moduloLogic = new ModuloLogic(new ModuloAdapter(context));
        }
        public ModuloDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
        }
        public ModuloDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            ModuloActual = _moduloLogic.GetOne(ID);
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
                    this.txtDescripcion.Enabled = false;
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
            MapearADatos();
            _moduloLogic.Save(ModuloActual);
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
            _moduloLogic.Delete(ModuloActual.ID);
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

