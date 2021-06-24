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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlMaterias_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Listar()
        {
            // Tengo que pedir la lista de planes y de materias
            MateriaLogic ml = new MateriaLogic();
            PlanLogic pl = new PlanLogic();
            List<Materia> materias = ml.GetAll();
            List<Plan> planes = pl.GetAll();
            // Tengo que cambiar el ID del plan por su descripción para mostrarlo
            // Puedo recorrer los arreglos y matchear o puedo usar LINQ y hacerlo mucho más fácil
            var consulta =
                            from m in materias
                            join p in planes
                            on m.IDPlan equals p.ID
                            select new
                            {
                                ID = m.ID,
                                Descripcion = m.Descripcion,
                                Horas_semanales = m.HSSemanales,
                                Horas_totales = m.HSTotales,
                                Plan = p.Descripcion
                            };
            // El DataSource de un dgv espera algo que implemente la interfaz ILIST, como por ej una lista
            // Entonces convierto lo que antes era algo anónimo a una lista
            this.dgvMaterias.DataSource = consulta.ToList();
            this.dgvMaterias.AutoGenerateColumns = false;
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            // this.tsMaterias.Visible = false;
            // this.tscMaterias.Visible = false;
            // this.panelDesktop.Visible = true;
            // formMateria.TopLevel = false;
            // formMateria.AutoScroll = true;
            // Esto es para sacarle el borde de windows
            // formMateria.FormBorderStyle = FormBorderStyle.None;
            // Esto es para que rellene todo el panel
            // formMateria.Dock = DockStyle.Fill;
            // this.panelDesktop.Controls.Add(formMateria);
            // //this.panelPrincipal.Tag = app;
            formMateria.ShowDialog();
            // formMateria.materias = this;

        }
        // public void volver()
        // {
        // this.panelDesktop.Visible = false;
        // this.tsMaterias.Visible = true;
        // this.tscMaterias.Visible = true;
        // this.Listar();
        // }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["ID"].Value;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["ID"].Value;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
