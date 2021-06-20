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
    public partial class PlanDesktop : ApplicationForm
    {
        public Plan PlanActual { set; get; }
        public PlanDesktop()
        {
            InitializeComponent();
        }
        // Este es el constructor cuando se da de alta alta, ya que solo tiene un arg
        public PlanDesktop(ModoForm modo) : this()
        {
            Modos = modo;
            // Cargo las especialidades para mostrarlas en el combobox
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> listaEsp = el.GetAll();
            this.cbEspecialidad.DataSource = listaEsp;
            // this.cbEspecialidad.DataSource = listToDataTable(listaEsp).DefaultView;
            this.cbEspecialidad.SelectedIndex = 0;
        }
        // Este es el constructor cuando se edita o elimina algo, ya que tiene dos args
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modos = modo;
            PlanLogic p = new PlanLogic();
            PlanActual = p.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            // Acá cuando cargo el plan tengo que buscar la especialidad asignada al plan
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad espActualPlan = el.GetOne(PlanActual.IDEspecialidad);
            // A su vez tengo que cargar las otras especialidades por si quiero seleccionar otra
            List<Especialidad> especialidades = el.GetAll();
            // seteo como datasource del combobox la lista de especialidades anteriores
            this.cbEspecialidad.DataSource = especialidades;
            // ahora tengo que seleccionar la especialidad correspondiente al plan actual
            this.cbEspecialidad.SelectedIndex = cbEspecialidad.FindStringExact(espActualPlan.Descripcion);
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
                    this.cbEspecialidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    this.cbEspecialidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                PlanActual.IDEspecialidad = (int)this.cbEspecialidad.SelectedValue;
            }
            if (Modos == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                PlanActual.IDEspecialidad = (int)this.cbEspecialidad.SelectedValue;
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            PlanLogic e = new PlanLogic();
            MapearADatos();
            e.Save(PlanActual);
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
        private void PlanDesktop_Load(object sender, EventArgs e)
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
            PlanLogic e = new PlanLogic();
            e.Delete(PlanActual.ID);
        }
    }
}
