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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        private AlumnoInscripcion AlumnoInscripcionActual { set; get; }
        public AlumnoInscripcionDesktop(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
        }
        public AlumnoInscripcionDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // No te deja hacer nada hasta que no introduzcas un legajo válido, como en usuario
            this.cbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                // Cargo los cursos para mostrarlos en el combobox
                List<Curso> cursos = _cursoLogic.GetAll();
                this.cbCurso.DataSource = cursos;
                // selecciono el curso de la posicion 0 como para seleccionar algo
                this.cbCurso.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Cursos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public AlumnoInscripcionDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                AlumnoInscripcionActual = _alumnoInscripcionLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlumnoInscripcionActual.ID.ToString();
            this.txtLegajo.Text = AlumnoInscripcionActual.Persona.Legajo.ToString();
            this.txtNombre.Text = AlumnoInscripcionActual.Persona.Nombre;
            this.txtApellido.Text = AlumnoInscripcionActual.Persona.Apellido;
            // Tengo que cargar los cursos por si quiero seleccionar otro
            // Y seleccionar el actual
            try
            {
                List<Curso> cursos = _cursoLogic.GetAll();
                this.cbCurso.DataSource = cursos;
                this.cbCurso.SelectedIndex = cbCurso.FindStringExact(AlumnoInscripcionActual.Curso.Descripcion);
            }
            catch (Exception e)
            {
                this.btnAceptar.Enabled = false;
                MessageBox.Show(e.Message, "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.txtLegajo.Enabled = false;
                    this.cbCurso.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            try
            {
                if (Modos == ModoForm.Alta)
                {
                    AlumnoInscripcionActual = new AlumnoInscripcion();
                    AlumnoInscripcionActual.Condicion = "";
                    AlumnoInscripcionActual.Nota = 0;
                }
                AlumnoInscripcionActual.IDCurso = (int)this.cbCurso.SelectedValue;
                AlumnoInscripcionActual.IDAlumno = _personaLogic.GetOneConLegajo(Int32.Parse(this.txtLegajo.Text)).ID;
                switch (Modos)
                {
                    case ModoForm.Alta:
                        AlumnoInscripcionActual.State = BusinessEntity.States.New;
                        break;
                    case ModoForm.Modificacion:
                        AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Personas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                if (Validar())
                {
                    _alumnoInscripcionLogic.Save(AlumnoInscripcionActual);
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new AlumnoInscripcionValidator().Validate(AlumnoInscripcionActual);
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
                // Valido que la persona ingresada sea un alumno
                if (per.TipoPersona != Business.Entities.Persona.TiposPersona.Alumno)
                {
                    Exception e = new Exception("El legajo ingresado no corresponde a un alumno.");
                    throw e;
                }
                // Asigno los datos de la persona a los textbox
                this.txtNombre.Text = per.Nombre;
                this.txtApellido.Text = per.Apellido;
                // Una vez que cargo la persona, vuelvo a habilitar el resto de los elementos
                this.btnAceptar.Enabled = true;
                this.cbCurso.DropDownStyle = ComboBoxStyle.DropDown;
            }
            catch (FormatException)
            {
                MessageBox.Show("El legajo ingresado debe ser un número", "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Personas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                _alumnoInscripcionLogic.Delete(AlumnoInscripcionActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            cargarPersona();
        }
    }
}
