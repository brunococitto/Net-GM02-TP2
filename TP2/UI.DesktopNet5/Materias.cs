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
    public partial class Materias : Form
    {
        private readonly MateriaLogic _materiaLogic;
        private readonly PlanLogic _planLogic;
        private readonly AcademyContext _context;
        public Materias(AcademyContext context)
        {
            InitializeComponent();
            _materiaLogic = new MateriaLogic(new MateriaAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
            _context = context;
        }
        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            // Tengo que pedir la lista de planes y de materias
            List<Materia> materias = _materiaLogic.GetAll();
            List<Plan> planes = _planLogic.GetAll();
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta, _context);
            formMateria.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["ID"].Value;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
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
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
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
