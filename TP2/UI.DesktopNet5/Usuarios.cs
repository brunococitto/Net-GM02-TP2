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
    public partial class Usuarios : Form
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly PersonaLogic _personaLogic;
        private readonly AcademyContext _context;
        public Usuarios(AcademyContext context)
        {
            InitializeComponent();
            _usuarioLogic = new UsuarioLogic(new UsuarioAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
            _context = context;
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            Singleton.getInstance().DgvActual = this.dgvUsuarios;
            Singleton.getInstance().ModuloActual = "Usuarios";
            this.Listar();
        }
        public void Listar()
        {
            // Pido las personas
            List<Persona> personas = _personaLogic.GetAll();
            // Pido los usuarios
            List<Usuario> usuarios = _usuarioLogic.GetAll();
            // Consulta para dejar la descripción del plan
            var consulta =
                            from u in usuarios
                            join p in personas
                            on u.IDPersona equals p.ID
                            select new
                            {
                                ID = u.ID,
                                Usuario = u.NombreUsuario,
                                Legajo = p.Legajo,
                                Nombre = p.Nombre,
                                Apellido = p.Apellido,
                                Habilitado = u.Habilitado
                            };
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.DataSource = consulta.ToList(); ;
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta, _context);
            formUsuario.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvUsuarios.SelectedRows[0].Cells[0].Value;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
            }

        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvUsuarios.SelectedRows[0].Cells[0].Value;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }
        }
    }
}
