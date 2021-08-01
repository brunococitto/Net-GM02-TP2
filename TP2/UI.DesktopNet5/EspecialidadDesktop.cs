using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            EspecialidadActual = _especialidadLogic.GetOne(ID);
            MapearDeDatos();
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
            MapearADatos();
            _especialidadLogic.Save(EspecialidadActual);
        }
        public override bool Validar()
        {
            try
            {
                Validaciones.ValidarNulo(this.txtDescripcion.Text, "descripcón");
                Validaciones.ValidarLetras(this.txtDescripcion.Text, "descripcón");
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public virtual void Eliminar()
        {
            _especialidadLogic.Delete(EspecialidadActual.ID);
        }
    }
}
