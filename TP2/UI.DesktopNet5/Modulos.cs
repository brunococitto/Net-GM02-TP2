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
    public partial class Modulos : Form
    {
        private readonly ModuloLogic _moduloLogic;
        private readonly AcademyContext _context;
        public Modulos(AcademyContext context)
        {
            InitializeComponent();
            _moduloLogic = new ModuloLogic(new ModuloAdapter(context));
            _context = context;
        }
        private void Modulos_Load(object sender, EventArgs e)
        {
            Singleton.getInstance().DgvActual = this.dgvModulos;
            Singleton.getInstance().ModuloActual = "Modulos";
            this.Listar();
        }
        public void Listar()
        {
            this.dgvModulos.AutoGenerateColumns = false;
            try
            {
                this.dgvModulos.DataSource = _moduloLogic.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Modulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloDesktop formModulo = new ModuloDesktop(ApplicationForm.ModoForm.Alta, _context);
            formModulo.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
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
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
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
