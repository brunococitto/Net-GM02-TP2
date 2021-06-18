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
    public partial class Modulos : Form
    {
        public Modulos()
        {
            InitializeComponent();
        }
        private void Modulos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tlModulos_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Listar()
        {
            ModuloLogic el = new ModuloLogic();
            this.dgvModulos.AutoGenerateColumns = false;
            this.dgvModulos.DataSource = el.GetAll();
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
            ModuloDesktop formModulo = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            formModulo.ShowDialog();
            this.Listar();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formModulo.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja);
                formModulo.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }

    }
}
