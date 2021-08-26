using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private readonly EspecialidadLogic _especialidadLogic;
        public EspecialidadDesktop(AcademyContext context)
        {
            InitializeComponent();
            _especialidadLogic = new EspecialidadLogic(new EspecialidadAdapter(context));
        }
        public EspecialidadDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                EspecialidadActual = _especialidadLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Especialidad EspecialidadActual { set; get; }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
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
                EspecialidadActual = new Especialidad();
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            if (Modos == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                if (Validar())
                {
                    _especialidadLogic.Save(EspecialidadActual);
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new EspecialidadValidator().Validate(EspecialidadActual);
            if (!result.IsValid)
            {
                string notificacion = string.Join(Environment.NewLine, result.Errors);
                MessageBox.Show(notificacion);
                return false;
            }
            return true;  
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modos)
            {
                case ModoForm.Alta:
                    {
                        GuardarCambios();
                    };
                    break;
                case ModoForm.Modificacion:
                    {
                        GuardarCambios();
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public virtual void Eliminar()
        {
            try
            {
                _especialidadLogic.Delete(EspecialidadActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
