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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            // Tengo que pedir la lista de comisiones y de planes
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            List<Comision> comisiones = cl.GetAll();
            // Tengo que cambiar el ID de la especialidad por su descripción para mostrarlo
            // Puedo recorrer los arreglos y matchear o puedo usar LINQ y hacerlo mucho más fácil
            var consulta =
                            from p in planes
                            join c in comisiones
                            on p.ID equals c.IDPlan
                            select new
                            {
                                ID = c.ID,
                                Descripcion = c.Descripcion,
                                AnoEspecialidad = c.AnoEspecialidad,
                                IDPlan = p.Descripcion
                            };
            // El DataSource de un dgv espera algo que implemente la interfaz ILIST, como por ej una lista
            // Entonces convierto lo que antes era algo anónimo a una lista
            this.dgvComisiones.DataSource = consulta.ToList();
            this.dgvComisiones.AutoGenerateColumns = false;

        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop formComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            {
                if (this.dgvComisiones.SelectedRows.Count > 0)
                {
                    int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["ID"].Value;
                    ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formComision.ShowDialog();
                    this.Listar();
                }
                else
                {
                    MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
                }

            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["ID"].Value;
                ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
