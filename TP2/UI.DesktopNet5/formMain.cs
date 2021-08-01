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
    public partial class formMain : Form
    {
        private readonly AcademyContext _context;
        public formMain(AcademyContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin(_context);
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.formMain_Shown(sender, e);
        }
        private void setForm(Form form)
        {
            if (this.pnlPrincipal.Controls.Count > 0)
            {
                this.pnlPrincipal.Controls[0].Dispose();
            }
            form.TopLevel = false;
            form.AutoScroll = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.pnlPrincipal.Tag = form;
            this.pnlPrincipal.Controls.Add(form);
            form.Show();
        }
        private void mnuComisiones_Click(object sender, EventArgs e)
        {
            setForm(new Comisiones(_context));
        }
        private void mnuCursos_Click(object sender, EventArgs e)
        {
            setForm(new Cursos(_context));
        }
        private void mnuEspecialidades_Click(object sender, EventArgs e)
        {
            setForm(new Especialidades(_context));
        }
        private void mnuMaterias_Click(object sender, EventArgs e)
        {
            setForm(new Materias(_context));
        }
        private void mnuModulos_Click(object sender, EventArgs e)
        {
            setForm(new Modulos(_context));
        }
        private void mnuPersonas_Click(object sender, EventArgs e)
        {
            setForm(new Personas(_context));
        }
        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            setForm(new Planes(_context));
        }
        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            setForm(new Usuarios(_context));
        }
        private void mnuInscripciones_Click(object sender, EventArgs e)
        {
            setForm(new AlumnoInscripciones(_context));
        }
        private void mnuRegistroNotas_Click(object sender, EventArgs e)
        {
            setForm(new RegistrarNotas(_context));
        }
    }
}
