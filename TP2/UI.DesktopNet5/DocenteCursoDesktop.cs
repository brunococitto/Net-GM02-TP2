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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private readonly DocenteCursoLogic _docenteCursoLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        private DocenteCurso DocenteCursoActual { set; get; }
        public DocenteCursoDesktop(AcademyContext context)
        {
            InitializeComponent();
            _docenteCursoLogic = new DocenteCursoLogic(new DocenteCursoAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
        }
        public DocenteCursoDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // No te deja hacer nada hasta que no introduzcas un legajo válido, como en usuario
            this.cbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            // Cargo los cursos para mostrarlos en el combobox
            List<Curso> cursos = _cursoLogic.GetAll();
            this.cbCurso.DataSource = cursos;
            // selecciono el curso de la posicion 0 como para seleccionar algo
            this.cbCurso.SelectedIndex = 0;
            // Cargos
            this.cbCargo.DataSource = Enum.GetNames(typeof(Business.Entities.DocenteCurso.TiposCargo));
        }
        public DocenteCursoDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            DocenteCursoActual = _docenteCursoLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.txtLegajo.Text = DocenteCursoActual.Persona.Legajo.ToString();
            this.txtNombre.Text = DocenteCursoActual.Persona.Nombre;
            this.txtApellido.Text = DocenteCursoActual.Persona.Apellido;
            // Tengo que cargar los cursos por si quiero seleccionar otro
            // Y seleccionar el actual
            List<Curso> cursos = _cursoLogic.GetAll();
            this.cbCurso.DataSource = cursos;
            this.cbCurso.SelectedIndex = cbCurso.FindStringExact(DocenteCursoActual.Curso.Descripcion);
            // Cargo
            this.cbCargo.DataSource = Enum.GetNames(typeof(Business.Entities.DocenteCurso.TiposCargo));
            // Tengo que seleccionar del combo de cargos el cargo del docente
            this.cbCargo.SelectedIndex = cbCargo.FindStringExact(Enum.GetName(DocenteCursoActual.Cargo));
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
                    this.txtLegajo.Enabled = false;
                    this.cbCurso.Enabled = false;
                    this.cbCargo.Enabled = false;
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
                DocenteCursoActual = new DocenteCurso();
            }
            DocenteCursoActual.IDCurso = (int)this.cbCurso.SelectedValue;
            DocenteCursoActual.IDDocente= _personaLogic.GetOneConLegajo(Int32.Parse(this.txtLegajo.Text)).ID;
            DocenteCursoActual.Cargo = (Business.Entities.DocenteCurso.TiposCargo)Enum.Parse(typeof(Business.Entities.DocenteCurso.TiposCargo), cbCargo.SelectedItem.ToString());
            switch (Modos)
            {
                case ModoForm.Alta:
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            if (Validar())
            {
                _docenteCursoLogic.Save(DocenteCursoActual);
                Close();
            }
                
        }
        public override bool Validar()
        {
            ValidationResult result = new DocenteCursoValidator().Validate(DocenteCursoActual);
            if (!result.IsValid)
            {
                string notificacion = string.Join(Environment.NewLine, result.Errors);
                MessageBox.Show(notificacion);
                return false;
            }
            return true;

        }
        private void cargarPersona()
        {
            this.btnAceptar.Enabled = false;
            this.cbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            try
            {
                Validaciones.ValidarNulo(this.txtLegajo.Text,"legajo");
                Validaciones.ValidarNumero(this.txtLegajo.Text,"legajo");
                Persona per = _personaLogic.GetOneConLegajo(Int32.Parse(this.txtLegajo.Text));
                if (per == null)
                {
                    Exception e = new Exception("No existe persona para el legajo ingresado.");
                    throw e;
                }
                // Valido que la persona ingresada sea un profesor
                if (per.TipoPersona != Business.Entities.Persona.TiposPersona.Profesor)
                {
                    Exception e = new Exception("El legajo ingresado no corresponde a un profesor.");
                    throw e;
                }
                // Asigno los datos de la persona a los textbox
                this.txtNombre.Text = per.Nombre;
                this.txtApellido.Text = per.Apellido;
                // Una vez que cargo la persona, vuelvo a habilitar el resto de los elementos
                this.btnAceptar.Enabled = true;
                this.cbCurso.DropDownStyle = ComboBoxStyle.DropDown;
                this.cbCargo.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Acá habría que validar que no exista ya una inscripcion para X alumno y X curso
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
            _docenteCursoLogic.Delete(DocenteCursoActual.ID);
        }
        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            cargarPersona();
        }
    }
}
