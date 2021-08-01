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
using System.Globalization;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private readonly PersonaLogic _personaLogic;
        private readonly PlanLogic _planLogic;
        private Persona PersonaActual { set; get; }
        public PersonaDesktop(AcademyContext context)
        {
            InitializeComponent();
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
        }
        public PersonaDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // Cargo los planes para mostrarlos en el combobox
            List<Plan> planes = _planLogic.GetAll();
            this.cbPlan.DataSource = planes;
            // selecciono el plan de la posicion 0 como para seleccionar algo
            this.cbPlan.SelectedIndex = 0;
            // Tipos persona
            this.cbTipoPersona.DataSource = Enum.GetNames(typeof(Business.Entities.Persona.TiposPersona));
        }
        public PersonaDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            PersonaActual = _personaLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            // Acá cuando cargo la persona tengo que buscar el plan asignado
            Plan planActualPersona = _planLogic.GetOne(PersonaActual.IDPlan);
            // A su vez tengo que cargar los otros planes por si quiero seleccionar otro
            List<Plan> planes = _planLogic.GetAll();
            // seteo como datasource del combobox la lista de planes
            this.cbPlan.DataSource = planes;
            // ahora tengo que seleccionar el plan correspondiente a la persona
            this.cbPlan.SelectedIndex = cbPlan.FindStringExact(planActualPersona.Descripcion);
            // Cargo la fecha
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
            // Tipos persona
            this.cbTipoPersona.DataSource = Enum.GetNames(typeof(Business.Entities.Persona.TiposPersona));
            // Tengo que seleccionar del combo de tipos el tipo de mi persona
            this.cbTipoPersona.SelectedIndex = cbTipoPersona.FindStringExact(Enum.GetName(PersonaActual.TipoPersona));
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
                PersonaActual = new Persona();
            }
            PersonaActual.Nombre = this.txtNombre.Text;
            PersonaActual.Apellido = this.txtApellido.Text;
            PersonaActual.Email = this.txtEmail.Text;
            PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
            PersonaActual.Telefono = this.txtTelefono.Text;
            PersonaActual.Direccion = this.txtDireccion.Text;
            PersonaActual.IDPlan = (int)this.cbPlan.SelectedValue;
            PersonaActual.FechaNacimiento = this.dtpFechaNacimiento.Value.Date;
            PersonaActual.TipoPersona = (Business.Entities.Persona.TiposPersona)Enum.Parse(typeof(Business.Entities.Persona.TiposPersona), cbTipoPersona.SelectedItem.ToString());
            switch (Modos)
            {
                case ModoForm.Alta:
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            _personaLogic.Save(PersonaActual);
        }
        public override bool Validar()
        {
            try
            {
                Validaciones.ValidarNulo(this.txtNombre.Text, "nombre");
                Validaciones.ValidarLetras(this.txtNombre.Text, "nombre");
                Validaciones.ValidarNulo(this.txtApellido.Text, "apellido");
                Validaciones.ValidarLetras(this.txtApellido.Text, "apellido");
                Validaciones.ValidarNulo(this.txtLegajo.Text, "legajo");
                Validaciones.ValidarNumero(this.txtLegajo.Text, "legajo");
                Validaciones.ValidarNulo(this.txtDireccion.Text, "dirección");
                Validaciones.ValidarLetrasNumeros(this.txtDireccion.Text, "dirección");
                Validaciones.ValidarNulo(this.txtTelefono.Text, "teléfono");
                Validaciones.ValidarNumero(this.txtTelefono.Text, "teléfono");
                Validaciones.ValidarNulo(this.txtEmail.Text, "email");
                Validaciones.ValidarEmail(this.txtEmail.Text);
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
            _personaLogic.Delete(PersonaActual.ID);
        }
    }
}
