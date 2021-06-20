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
using FastMember;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        public Plan PlanActual { set; get; }
        public PlanDesktop()
        {
            InitializeComponent();
        }
        public PlanDesktop(ModoForm modo) : this()
        {
            Modos = modo;
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> listaEsp = el.GetAll();
            this.cbEspecialidad.DataSource = listToDataTable(listaEsp).DefaultView;
            //this.cbEspecialidad.SelectedIndex = 0;
        }
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
            // El tema es que lo anterior me da una lista y yo necesito un datatable
            // asi que necesito un metodo que convierta list a datatable
            this.cbEspecialidad.DataSource = listToDataTable(especialidades).DefaultView;
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
                PlanActual = new Plan();
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = (int)this.cbEspecialidad.SelectedValue;
            }
            if (Modos == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Este método sirve para convertir de la lista que devuelve el método GetAll
        // Al DataTable necesario para cargar el combo box de especialidades
        private DataTable listToDataTable(List<Especialidad> listaEsp)
        {
            // lo hice siguiendo el primer comentario de
            // https://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable
            DataTable dataTable = new DataTable();
            using (var reader = ObjectReader.Create(listaEsp))
            {
                dataTable.Load(reader);
            }
            return dataTable;
        }
    }
}
