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
    public partial class Cursos : Form
    {
        private readonly ComisionLogic _comisionLogic;
        private readonly MateriaLogic _materiaLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly AcademyContext _context;
        public Cursos(AcademyContext context)
        {
            InitializeComponent();
            _comisionLogic = new ComisionLogic(new ComisionAdapter(context));
            _materiaLogic = new MateriaLogic(new MateriaAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
            _context = context;
        }
        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            try
            {
                // Tengo que pedir la lista de cursos de materias y comisiones
                List<Materia> materias = _materiaLogic.GetAll();
                List<Comision> comisiones = _comisionLogic.GetAll();
                List<Curso> cursos = _cursoLogic.GetAll();
                // Tengo que cambiar el ID del plan por su descripción para mostrarlo
                // Puedo recorrer los arreglos y matchear o puedo usar LINQ y hacerlo mucho más fácil
                var consulta =
                                from c in cursos
                                join m in materias
                                on c.IDMateria equals m.ID
                                join com in comisiones on c.IDComision equals com.ID
                                select new
                                {
                                    ID = c.ID,
                                    DescripcionCur = c.Descripcion,
                                    DescripcionMat = m.Descripcion,
                                    DescripcionCom = com.Descripcion,
                                    AnoCalendario = c.AnoCalendario,
                                    Cupo = c.Cupo,

                                };
                // El DataSource de un dgv espera algo que implemente la interfaz ILIST, como por ej una lista
                // Entonces convierto lo que antes era algo anónimo a una lista
                this.dgvCursos.DataSource = consulta.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvCursos.AutoGenerateColumns = false;
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta, _context);
            formCurso.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["ID"].Value;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                formCurso.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }

        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["ID"].Value;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formCurso.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
