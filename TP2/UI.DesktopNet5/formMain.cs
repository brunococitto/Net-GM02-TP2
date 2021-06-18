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
            appUsuarios.ShowDialog();
        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades appEspecialidades = new Especialidades();
            appEspecialidades.ShowDialog();
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {
            Modulos appModulos = new Modulos();
            appModulos.ShowDialog();
        }
    }
}
