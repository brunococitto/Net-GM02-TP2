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
    public partial class DocenteCursos : Form
    {
        private readonly DocenteCursoLogic _docenteCursoLogic;
        private readonly AcademyContext _context;
        public DocenteCursos(AcademyContext context)
        {
            InitializeComponent();
            _docenteCursoLogic = new DocenteCursoLogic(new DocenteCursoAdapter(context));
            _context = context;
        }
        private void DocenteCursos_Load(object sender, EventArgs e)
        {
            Singleton.getInstance().DgvActual = this.dgvDocenteCursos;
            Singleton.getInstance().ModuloActual = "Docentes cursos";
            this.Listar();
        }
        public void Listar()
        {
            try
            {
                this.dgvDocenteCursos.DataSource = _docenteCursoLogic.GetAsignacionesFormateadas();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvDocenteCursos.AutoGenerateColumns = false;
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
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta, _context);
            formDocenteCurso.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocenteCursos.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvDocenteCursos.SelectedRows[0].Cells[0].Value;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocenteCursos.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvDocenteCursos.SelectedRows[0].Cells[0].Value;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
