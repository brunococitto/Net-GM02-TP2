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
using FluentValidation;
using FluentValidation.Results;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private readonly MateriaLogic _materiaLogic;
        private readonly PlanLogic _planLogic;
        public Materia MateriaActual { set; get; }
        public MateriaDesktop(AcademyContext context)
        {
            InitializeComponent();
            _materiaLogic = new MateriaLogic(new MateriaAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
        }
        // Este es el constructor cuando se da de alta alta, ya que solo tiene un arg
        public MateriaDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // Cargo los planes para mostrarlos en el combobox
            try
            {
                List<Plan> listaPlanes = _planLogic.GetAll();
                this.cbPlan.DataSource = listaPlanes;
                // selecciono el plan de la posicion 0 como para seleccionar algo
                this.cbPlan.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Este es el constructor cuando se edita o elimina algo, ya que tiene dos args
        public MateriaDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                MateriaActual = _materiaLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.nudHorasSemanales.Value = this.MateriaActual.HSSemanales;
            this.nudHorasTotales.Value = this.MateriaActual.HSTotales;
            try
            {
                // Acá cuando cargo la materia tengo que buscar el plan asignado
                Plan planActualMateria = _planLogic.GetOne(MateriaActual.IDPlan);
                // A su vez tengo que cargar los otros planes por si quiero seleccionar otro
                List<Plan> planes = _planLogic.GetAll();
                // seteo como datasource del combobox la lista de planes anteriores
                this.cbPlan.DataSource = planes;
                // ahora tengo que seleccionar el plan correspondiente a la materia
                this.cbPlan.SelectedIndex = cbPlan.FindStringExact(planActualMateria.Descripcion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    this.cbPlan.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.nudHorasSemanales.Enabled = false;
                    this.nudHorasTotales.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    this.cbPlan.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.nudHorasSemanales.Enabled = false;
                    this.nudHorasTotales.Enabled = false;
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                MateriaActual.IDPlan = (int)this.cbPlan.SelectedValue;
                MateriaActual.HSSemanales = (int)this.nudHorasSemanales.Value;
                MateriaActual.HSTotales = (int)this.nudHorasTotales.Value;
            }
            if (Modos == ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                MateriaActual.IDPlan = (int)this.cbPlan.SelectedValue;
                MateriaActual.HSSemanales = (int)this.nudHorasSemanales.Value;
                MateriaActual.HSTotales = (int)this.nudHorasTotales.Value;
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
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
                    _materiaLogic.Save(MateriaActual);
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new MateriaValidator().Validate(MateriaActual);
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
                _materiaLogic.Delete(MateriaActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
