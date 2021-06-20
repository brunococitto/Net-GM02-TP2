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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlPlanes_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Listar()
        {
            // Tengo que pedir la lista de especialidades y de planes
            PlanLogic pl = new PlanLogic();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Plan> planes = pl.GetAll();
            List<Especialidad> especialidades = el.GetAll();
            // Tengo que cambiar el ID de la especialidad por su descripción para mostrarlo
            // Puedo recorrer los arreglos y matchear o puedo usar LINQ y hacerlo mucho más fácil
            var consulta =
                            from p in planes
                            join e in especialidades
                            on p.IDEspecialidad equals e.ID
                            select new
                            {
                                ID = p.ID,
                                Descripcion = p.Descripcion,
                                Especialidad = e.Descripcion
                            };
            // Cada uno de los objetos nuevos tiene ID (plan), Descripción (plan) y Especialidad (descripcion especialidad)
            // El DataSource de un dgv espera algo que implemente la interfaz ILIST, como por ej una lista
            // Entonces convierto lo que antes era algo anónimo a una lista
            this.dgvPlanes.DataSource = consulta.ToList();
            this.dgvPlanes.AutoGenerateColumns = false;
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["ID"].Value;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["ID"].Value;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
