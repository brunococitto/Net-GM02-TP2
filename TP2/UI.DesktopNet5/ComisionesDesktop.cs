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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class ComisionesDesktop : ApplicationForm
    {
        private readonly ComisionLogic _comisionLogic;
        private readonly PlanLogic _planLogic;
        public ComisionesDesktop(AcademyContext context)
        {
            InitializeComponent();
            _comisionLogic = new ComisionLogic(new ComisionAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
        }

        public ComisionesDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // Cargo los planes para mostrarlos en el combobox
            List<Plan> listaPlanes = _planLogic.GetAll();
            this.comboBoxIDPlan.DataSource = listaPlanes;
            // selecciono el plan de la posicion 0 como para seleccionar algo
            this.comboBoxIDPlan.SelectedIndex = 0;
        }

        public ComisionesDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            ComisionActual = _comisionLogic.GetOne(ID);
            MapearDeDatos();
        }

        public Comision ComisionActual { set; get; }

        public override void MapearDeDatos()
        {
            this.txtBoxID.Text = this.ComisionActual.ID.ToString();
            this.txtBoxDesc.Text = this.ComisionActual.Descripcion;
            this.txtBoxAnioEspecialidad.Text = this.ComisionActual.AnoEspecialidad.ToString();
            // Acá cuando cargo la comi tengo que buscar el plan 
            Plan planActualComi = _planLogic.GetOne(ComisionActual.IDPlan);
            // A su vez tengo que cargar los otros planes
            List<Plan> planes = _planLogic.GetAll();
            // seteo como datasource del combobox la lista de planes anteriores
            this.comboBoxIDPlan.DataSource = planes;
            // ahora tengo que seleccionar el plan correspondiente a la comi actual
            this.comboBoxIDPlan.SelectedIndex = comboBoxIDPlan.FindStringExact(planActualComi.Descripcion);
            switch (this.Modos)
            {
                case ModoForm.Alta:
                    this.bAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.bAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.bAceptar.Text = "Eliminar";
                    this.comboBoxIDPlan.Enabled = false;
                    this.txtBoxDesc.Enabled = false;
                    this.txtBoxAnioEspecialidad.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.bAceptar.Text = "Aceptar";
                    this.comboBoxIDPlan.Enabled = false;
                    this.txtBoxDesc.Enabled = false;
                    this.txtBoxAnioEspecialidad.Enabled = false;
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                ComisionActual = new Comision();
                ComisionActual.Descripcion = this.txtBoxDesc.Text;
                ComisionActual.IDPlan = (int)this.comboBoxIDPlan.SelectedValue;
                ComisionActual.AnoEspecialidad = Convert.ToInt32(this.txtBoxAnioEspecialidad.Text);
            }
            if (Modos == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtBoxDesc.Text;
                ComisionActual.IDPlan = (int)this.comboBoxIDPlan.SelectedValue;
                ComisionActual.AnoEspecialidad = Convert.ToInt32(this.txtBoxAnioEspecialidad.Text);

            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            _comisionLogic.Save(ComisionActual);
        }

         public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtBoxAnioEspecialidad.Text) || string.IsNullOrWhiteSpace(this.txtBoxDesc.Text))
            {
                Notificar("Error", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(Regex.IsMatch(this.txtBoxAnioEspecialidad.ToString(), @"[a-z,A-Z]+$"))
            {
                Notificar("Error", "El año especialidad debe de ser un numero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else { return true; }

        }

        private void bAceptar_Click(object sender, EventArgs e)
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
            _comisionLogic.Delete(ComisionActual.ID);
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxIDPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
