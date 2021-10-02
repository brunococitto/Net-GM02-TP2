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
using FluentValidation;
using FluentValidation.Results;

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
            try
            {
                List<Plan> planes = _planLogic.GetAll();
                this.cbPlan.DataSource = planes;
                // selecciono el plan de la posicion 0 como para seleccionar algo
                this.cbPlan.SelectedIndex = 0;
                // Tipos persona
                this.cbTipoPersona.DataSource = Enum.GetNames(typeof(Business.Entities.Persona.TiposPersona));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public PersonaDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                PersonaActual = _personaLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                List<Plan> planes = _planLogic.GetAll();
                this.cbPlan.DataSource = planes;
                if (PersonaActual.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    this.cbPlan.Enabled = false;
                    if (PersonaActual == Singleton.getInstance().PersonaLogged)
                    {
                        this.cbTipoPersona.Enabled = false;
                    }
                }
                else
                {
                    this.cbPlan.Enabled = true;
                    // Acá cuando cargo la persona tengo que buscar el plan asignado
                    Plan planActualPersona = _planLogic.GetOne((int)PersonaActual.IDPlan);
                    // ahora tengo que seleccionar el plan correspondiente a la persona
                    this.cbPlan.SelectedIndex = cbPlan.FindStringExact(planActualPersona.Descripcion);
                }
                // Cargo la fecha
                this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
                // Tipos persona
                this.cbTipoPersona.DataSource = Enum.GetNames(typeof(Business.Entities.Persona.TiposPersona));
                // Tengo que seleccionar del combo de tipos el tipo de mi persona
                this.cbTipoPersona.SelectedIndex = cbTipoPersona.FindStringExact(Enum.GetName(PersonaActual.TipoPersona));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Personas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.txtNombre.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.dtpFechaNacimiento.Enabled = false;
                    this.cbTipoPersona.Enabled = false;
                    this.txtLegajo.Enabled = false;
                    this.txtApellido.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.cbPlan.Enabled = false;
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
            PersonaActual.FechaNacimiento = this.dtpFechaNacimiento.Value.Date;
            PersonaActual.TipoPersona = (Business.Entities.Persona.TiposPersona)Enum.Parse(typeof(Business.Entities.Persona.TiposPersona), cbTipoPersona.SelectedItem.ToString());
            if (PersonaActual.TipoPersona == Persona.TiposPersona.Administrativo)
            {
                PersonaActual.IDPlan = null;
            }
            else
            {
                PersonaActual.IDPlan = (int)this.cbPlan.SelectedValue;
            }
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
            try
            {
                MapearADatos();
                if (Validar())
                {
                    _personaLogic.Save(PersonaActual);
                    Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El legajo ingresado debe ser un número", "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new PersonaValidator().Validate(PersonaActual);
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
                _personaLogic.Delete(PersonaActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoPersona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if ((Business.Entities.Persona.TiposPersona)Enum.Parse(typeof(Business.Entities.Persona.TiposPersona), this.cbTipoPersona.SelectedItem.ToString()) == Persona.TiposPersona.Administrativo)
            {
                this.cbPlan.Enabled = false;
            } else
            {
                this.cbPlan.Enabled = true;
            }
        }
    }
}
