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

namespace UI.Desktop
{
    public partial class RegistrarNotas : Form
    {
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        private readonly DocenteCursoLogic _docenteCursoLogic;
        private readonly AcademyContext _context;
        public RegistrarNotas(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _docenteCursoLogic = new DocenteCursoLogic(new DocenteCursoAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _context = context;
        }
        private void RegistrarNotas_Load(object sender, EventArgs e)
        {
            Singleton.getInstance().DgvActual = this.dgvRegistrarNotas;
            Singleton.getInstance().ModuloActual = "Notas";
            this.gbModificarInscripcion.Enabled = false;
            this.ListarCursos();
        }
        public void ListarCursos()
        {
            // Solo cargo los cursos del profe logueado
            List<Curso> cursos = _docenteCursoLogic.GetCursosProfesor(Singleton.getInstance().PersonaLogged.ID);
            cbCursos.DataSource = cursos;
            if (cursos.Count > 0 )
            {
                cbCursos.SelectedIndex = 0;
                Listar();
            }
            else
            {
                MessageBox.Show("No hay cursos registrados para el profesor.");
            }
        }
        public void Listar()
        {
            try
            {
                // Pido las alumnoInscripciones
                List<AlumnoInscripcion> alumnoInscripciones = _alumnoInscripcionLogic.GetInscripcionesCurso((int)this.cbCursos.SelectedValue);
                // Pido las personas
                List<Persona> personas = _personaLogic.GetAll();
                // Consulta para dejar la descripción del plan
                var consulta =
                                from insc in alumnoInscripciones
                                join per in personas
                                on insc.IDAlumno equals per.ID
                                select new
                                {
                                    ID = insc.ID,
                                    Legajo = per.Legajo,
                                    Nombre = per.Nombre,
                                    Apellido = per.Apellido,
                                    Condicion = insc.Condicion,
                                    Nota = insc.Nota
                                };
                this.dgvRegistrarNotas.DataSource = consulta.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvRegistrarNotas.AutoGenerateColumns = false;
        }
        private void CargarDatosInscripcion()
        {
            try
            {
                AlumnoInscripcion insc = _alumnoInscripcionLogic.GetOne((int)this.dgvRegistrarNotas.SelectedRows[0].Cells[0].Value);
                Persona per = _personaLogic.GetOne(insc.IDAlumno);
                this.txtNombre.Text = per.Nombre;
                this.txtApellido.Text = per.Apellido;
                this.txtCondicion.Text = insc.Condicion;
                this.nudNota.Value = insc.Nota;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Datos Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbCursos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void dgvRegistrarNotas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.gbModificarInscripcion.Enabled = true;
            this.CargarDatosInscripcion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                AlumnoInscripcion insc = _alumnoInscripcionLogic.GetOne((int)this.dgvRegistrarNotas.SelectedRows[0].Cells[0].Value);

                insc.Condicion = this.txtCondicion.Text;
                insc.Nota = (int)this.nudNota.Value;
                insc.State = BusinessEntity.States.Modified;
                _alumnoInscripcionLogic.Save(insc);

                this.txtApellido.Text = "";
                this.txtNombre.Text = "";
                this.txtCondicion.Text = "";
                this.nudNota.Value = 0;
                this.gbModificarInscripcion.Enabled = false;
                this.Listar();
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message, "Datos Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void dgvRegistrarNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.gbModificarInscripcion.Enabled = false;
        }
    }
}
