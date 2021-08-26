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
using FluentValidation;
using FluentValidation.Results;

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
            try
            {
                List<Plan> listaPlanes = _planLogic.GetAll();
                this.comboBoxIDPlan.DataSource = listaPlanes;
                // selecciono el plan de la posicion 0 como para seleccionar algo
                this.comboBoxIDPlan.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ComisionesDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                ComisionActual = _comisionLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Comision ComisionActual { set; get; }

        public override void MapearDeDatos()
        {
            this.txtBoxID.Text = this.ComisionActual.ID.ToString();
            this.txtBoxDesc.Text = this.ComisionActual.Descripcion;
            this.nudAnioEspecialidad.Value = this.ComisionActual.AnoEspecialidad;
            // Acá cuando cargo la comi tengo que buscar el plan 
            try
            {
                Plan planActualComi = _planLogic.GetOne(ComisionActual.IDPlan);
                // A su vez tengo que cargar los otros planes
                List<Plan> planes = _planLogic.GetAll();
                // seteo como datasource del combobox la lista de planes anteriores
                this.comboBoxIDPlan.DataSource = planes;
                // ahora tengo que seleccionar el plan correspondiente a la comi actual
                this.comboBoxIDPlan.SelectedIndex = comboBoxIDPlan.FindStringExact(planActualComi.Descripcion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    this.nudAnioEspecialidad.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.bAceptar.Text = "Aceptar";
                    this.comboBoxIDPlan.Enabled = false;
                    this.txtBoxDesc.Enabled = false;
                    this.nudAnioEspecialidad.Enabled = false;
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
                ComisionActual.AnoEspecialidad = (int)this.nudAnioEspecialidad.Value;
            }
            if (Modos == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = this.txtBoxDesc.Text;
                ComisionActual.IDPlan = (int)this.comboBoxIDPlan.SelectedValue;
                ComisionActual.AnoEspecialidad = (int)this.nudAnioEspecialidad.Value;

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
            try
            {
                MapearADatos();
                if (Validar())
                {
                    _comisionLogic.Save(ComisionActual);
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

         public override bool Validar()
         {
            ValidationResult result = new ComisionValidator().Validate(ComisionActual);
            if (!result.IsValid)
            {
                string notificacion = string.Join(Environment.NewLine, result.Errors);
                MessageBox.Show(notificacion);
                return false;
            }
            return true;

         }

        private void bAceptar_Click(object sender, EventArgs e)
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

        public virtual void Eliminar()
        {
            try
            {
                _comisionLogic.Delete(ComisionActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
