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
        private readonly AcademyContext _context;
        public RegistrarNotas(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _context = context;
        }
        private void RegistrarNotas_Load(object sender, EventArgs e)
        {
            this.gbModificarInscripcion.Enabled = false;
            this.ListarCursos();
        }
        public void ListarCursos()
        {
            //  Contemplar la posibilidad de que n
            List<Curso> cursos = _cursoLogic.GetAll();
            cbCursos.DataSource = cursos;
            cbCursos.SelectedIndex = 0;
            Listar();
        }
        public void Listar()
        {
            // Pido las alumnoInscripciones
            List<AlumnoInscripcion> alumnoInscripciones = _alumnoInscripcionLogic.GetAll();
            // Pido las personas
            List<Persona> personas = _personaLogic.GetAll();
            // Consulta para dejar la descripción del plan
            var consulta =
                            from insc in alumnoInscripciones
                            join per in personas
                            on insc.IDAlumno equals per.ID
                            where insc.IDCurso == (int)this.cbCursos.SelectedValue
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
            this.dgvRegistrarNotas.AutoGenerateColumns = false;
        }
        private void CargarDatosInscripcion()
        {
            AlumnoInscripcion insc = _alumnoInscripcionLogic.GetOne((int)this.dgvRegistrarNotas.SelectedRows[0].Cells[0].Value);
            Persona per = _personaLogic.GetOne(insc.IDAlumno);
            this.txtNombre.Text = per.Nombre;
            this.txtApellido.Text = per.Apellido;
            this.txtCondicion.Text = insc.Condicion;
            this.txtNota.Text = insc.Nota.ToString();
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
            AlumnoInscripcion insc = _alumnoInscripcionLogic.GetOne((int)this.dgvRegistrarNotas.SelectedRows[0].Cells[0].Value);
            insc.Condicion = this.txtCondicion.Text;
            insc.Nota = Int32.Parse(this.txtNota.Text);
            insc.State = BusinessEntity.States.Modified;
            _alumnoInscripcionLogic.Save(insc);
            this.txtApellido.Text = "";
            this.txtNombre.Text = "";
            this.txtCondicion.Text = "";
            this.txtNota.Text = "";
            this.gbModificarInscripcion.Enabled = false;
            this.Listar();
        }
    }
}
