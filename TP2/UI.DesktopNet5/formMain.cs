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

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.formMain_Shown(sender, e);
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes appPlanes = new Planes();
            appPlanes.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias appMaterias = new Materias();
            appMaterias.ShowDialog();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            Comisiones appComisiones = new Comisiones();
            appComisiones.ShowDialog(); 
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            Cursos appCursos = new Cursos();
            appCursos.ShowDialog();
        }
    }
}
