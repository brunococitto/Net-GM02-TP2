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

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { set; get; }
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        // Este es el constructor cuando se da de alta alta, ya que solo tiene un arg
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modos = modo;
            // Cargo los planes para mostrarlos en el combobox
            PlanLogic pl = new PlanLogic();
            List<Plan> listaPlanes = pl.GetAll();
            this.cbPlan.DataSource = listaPlanes;
            // selecciono el plan de la posicion 0 como para seleccionar algo
            this.cbPlan.SelectedIndex = 0;
        }
        // Este es el constructor cuando se edita o elimina algo, ya que tiene dos args
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modos = modo;
            MateriaLogic m = new MateriaLogic();
            MateriaActual = m.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHorasSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HSTotales.ToString();
            // Acá cuando cargo la materia tengo que buscar el plan asignado
            PlanLogic pl = new PlanLogic();
            Plan planActualMateria = pl.GetOne(MateriaActual.IDPlan);
            // A su vez tengo que cargar los otros planes por si quiero seleccionar otro
            List<Plan> planes = pl.GetAll();
            // seteo como datasource del combobox la lista de planes anteriores
            this.cbPlan.DataSource = planes;
            // ahora tengo que seleccionar el plan correspondiente a la materia
            this.cbPlan.SelectedIndex = cbPlan.FindStringExact(planActualMateria.Descripcion);
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
                    this.txtHorasSemanales.Enabled = false;
                    this.txtHorasTotales.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    this.cbPlan.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.txtHorasSemanales.Enabled = false;
                    this.txtHorasTotales.Enabled = false;
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
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHorasSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHorasTotales.Text);
            }
            if (Modos == ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                MateriaActual.IDPlan = (int)this.cbPlan.SelectedValue;
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHorasSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHorasTotales.Text);
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
            MateriaLogic m = new MateriaLogic();
            MapearADatos();
            m.Save(MateriaActual);
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
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
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
            MateriaLogic e = new MateriaLogic();
            e.Delete(MateriaActual.ID);
        }
    }
}
