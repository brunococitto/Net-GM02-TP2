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
    public partial class RegistrarNotaDesktop : ApplicationForm
    {
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        private AlumnoInscripcion AlumnoInscripcionActual { set; get; }
        public RegistrarNotaDesktop(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
        }
        public RegistrarNotaDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // No te deja hacer nada hasta que no introduzcas un legajo válido, como en usuario
            this.txtCondicion.ReadOnly = true;
            this.txtNota.ReadOnly = true;
            this.cbCurso.Enabled = false;
            // Cargo los cursos para mostrarlos en el combobox
            List<Curso> cursos = _cursoLogic.GetAll();
            this.cbCurso.DataSource = cursos;
            // selecciono el curso de la posicion 0 como para seleccionar algo
            this.cbCurso.SelectedIndex = 0;
        }
        public RegistrarNotaDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            AlumnoInscripcionActual = _alumnoInscripcionLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlumnoInscripcionActual.ID.ToString();
            this.txtCondicion.Text = this.AlumnoInscripcionActual.Condicion;
            this.txtNota.Text = this.AlumnoInscripcionActual.Nota.ToString();
            // Acá cuando cargo la inscripcion tengo que buscar el alumno asignado
            Persona alumnoActual = _personaLogic.GetOne(this.AlumnoInscripcionActual.IDAlumno);
            this.txtLegajo.Text = alumnoActual.Legajo.ToString();
            this.txtNombre.Text = alumnoActual.Nombre;
            this.txtApellido.Text = alumnoActual.Apellido;
            // Acá cuando cargo la inscripcion tengo que buscar el curso asignado
            Curso cursoActual = _cursoLogic.GetOne(this.AlumnoInscripcionActual.IDCurso);
            // A su vez tengo que cargar los otros cursos por si quiero seleccionar otro
            // Y seleccionar el actual
            List<Curso> cursos = _cursoLogic.GetAll();
            this.cbCurso.DataSource = cursos;
            this.cbCurso.SelectedIndex = cbCurso.FindStringExact(cursoActual.Descripcion);
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
                AlumnoInscripcionActual = new AlumnoInscripcion();
            }
            AlumnoInscripcionActual.Condicion = this.txtCondicion.Text;
            AlumnoInscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
            AlumnoInscripcionActual.IDCurso = (int)this.cbCurso.SelectedValue;
            var alumno = from p in _personaLogic.GetAll()
                           where p.Legajo == Int32.Parse(this.txtLegajo.Text)
                           select p;
            AlumnoInscripcionActual.IDAlumno = (int)alumno.ToList()[0].ID;
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
        public override void GuardarCambios()
        {
            MapearADatos();
            _alumnoInscripcionLogic.Save(AlumnoInscripcionActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(this.txtApellido.Text) || string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtLegajo.Text))
            {
                Notificar("Error", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else { return true; }
        }
        private void cargarPersona()
        {
            this.btnAceptar.Enabled = false;
            this.txtCondicion.ReadOnly = true;
            this.cbCurso.Enabled = false;
            this.txtNota.ReadOnly = true;
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            List<Persona> personas = _personaLogic.GetAll();
            try
            {
                // Esta validacion tiene q ser q no es vacio y q son solo numeros
                // Metele regex a este if pa
                if (this.txtLegajo.Text.Length == 0)
                {
                    Exception e = new Exception("Ingrese un legajo.");
                    throw e;
                }
                var persona = (from p in personas
                               where p.Legajo == Int32.Parse(this.txtLegajo.Text)
                               select p).ToList();
                if (persona.Count == 0)
                {
                    Exception e = new Exception("No existe persona para el legajo ingresado.");
                    throw e;
                }
                Persona per = _personaLogic.GetOne(persona[0].ID);
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
                this.txtCondicion.ReadOnly = false;
                this.cbCurso.Enabled = true;
                this.txtNota.ReadOnly = false;
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
            _personaLogic.Delete(AlumnoInscripcionActual.ID);
        }

        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            cargarPersona();
        }
    }
}
