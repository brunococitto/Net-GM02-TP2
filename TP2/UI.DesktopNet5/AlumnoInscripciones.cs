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
    public partial class AlumnoInscripciones : Form
    {
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        private readonly AcademyContext _context;
        public AlumnoInscripciones(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _context = context;
        }
        private void AlumnoInscripciones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            // Pido las alumnoInscripciones
            List<AlumnoInscripcion> alumnoInscripciones = _alumnoInscripcionLogic.GetAll();
            // Pido los cursos
            List<Curso> cursos = _cursoLogic.GetAll();
            // Pido las personas
            List<Persona> personas = _personaLogic.GetAll();
            // Consulta para dejar la descripción del plan
            var consulta =
                            from insc in alumnoInscripciones
                            join cu in cursos
                            on insc.IDCurso equals cu.ID
                            join per in personas
                            on insc.IDAlumno equals per.ID
                            select new
                            {
                                ID = insc.ID,
                                Legajo = per.Legajo,
                                Nombre = per.Nombre,
                                Apellido = per.Apellido,
                                Curso = cu.Descripcion,
                                Condicion = insc.Condicion,
                                Nota = insc.Nota
                            };
            this.dgvAlumnoInscripciones.DataSource = consulta.ToList();
            this.dgvAlumnoInscripciones.AutoGenerateColumns = false;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta, _context);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnoInscripciones.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvAlumnoInscripciones.SelectedRows[0].Cells[0].Value;
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnoInscripciones.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvAlumnoInscripciones.SelectedRows[0].Cells[0].Value;
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
