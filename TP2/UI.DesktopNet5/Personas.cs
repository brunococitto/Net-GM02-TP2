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
    public partial class Personas : Form
    {
        private readonly PersonaLogic _personaLogic;
        private readonly PlanLogic _planLogic;
        private readonly AcademyContext _context;
        public Personas(AcademyContext context)
        {
            InitializeComponent();
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
            _context = context;
        }
        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            // Pido las personas
            List<Persona> personas = _personaLogic.GetAll();
            // Pido los planes
            List<Plan> planes = _planLogic.GetAll();
            // Consulta para dejar la descripción del plan
            var consulta =
                            from per in personas
                            join pl in planes
                            on per.IDPlan equals pl.ID
                            select new
                            {
                                ID = per.ID,
                                Legajo = per.Legajo,
                                Nombre = per.Nombre,
                                Apellido = per.Apellido,
                                Direccion = per.Direccion,
                                Telefono = per.Telefono,
                                Email = per.Email,
                                FechaNacimiento = per.FechaNacimiento,
                                Plan = pl.Descripcion,
                                TipoPersona = per.TipoPersona.ToString()
                            };
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DataSource = consulta.ToList();
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
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta, _context);
            formPersona.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells[0].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                formPersona.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells[0].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formPersona.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
