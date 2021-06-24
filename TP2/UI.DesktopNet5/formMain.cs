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
    public partial class formMain : Form
    {
        private void AbrirFormEnPanel(Form app)
        {
            // Tengo que chequear si ya hay algo abierto en el panel primero
            if (this.panelPrincipal.Controls.Count > 0 )
            {
                this.panelPrincipal.Controls[0].Dispose();
            }
            app.TopLevel = false;
            app.AutoScroll = true;
            // Esto es para sacarle el borde de windows
            app.FormBorderStyle = FormBorderStyle.None;
            // Esto es para que rellene todo el panel
            app.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(app);
            //this.panelPrincipal.Tag = app;
            app.Show();
        }
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios appUsuarios = new Usuarios();
            AbrirFormEnPanel(appUsuarios);
            //appUsuarios.ShowDialog();

        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades appEspecialidades = new Especialidades();
            //appEspecialidades.ShowDialog();
            AbrirFormEnPanel(appEspecialidades);
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {
            Modulos appModulos = new Modulos();
            //appModulos.ShowDialog();
            AbrirFormEnPanel(appModulos);
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.formMain_Shown(sender, e);
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes appPlanes = new Planes();
            //appPlanes.ShowDialog();
            AbrirFormEnPanel(appPlanes);
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias appMaterias = new Materias();
            //appMaterias.ShowDialog();
            AbrirFormEnPanel(appMaterias);
        }
    }
}
