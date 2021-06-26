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

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlMaterias_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Listar()
        {
            // Tengo que pedir la lista de cursos de materias y comisiones
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic coml = new ComisionLogic();
            List<Materia> materias = ml.GetAll();
            List<Comision> comisiones = coml.GetAll();
            List<Curso> cursos = cl.GetAll();
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["ID"].Value;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
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
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
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
