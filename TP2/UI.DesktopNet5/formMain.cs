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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios appUsuarios = new Usuarios(_context);
            appUsuarios.ShowDialog();
        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades appEspecialidades = new Especialidades(_context);
            appEspecialidades.ShowDialog();
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {
            Modulos appModulos = new Modulos(_context);
            appModulos.ShowDialog();
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.formMain_Shown(sender, e);
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes appPlanes = new Planes(_context);
            appPlanes.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias appMaterias = new Materias(_context);
            appMaterias.ShowDialog();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            Comisiones appComisiones = new Comisiones(_context);
            appComisiones.ShowDialog(); 
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            Cursos appCursos = new Cursos(_context);
            appCursos.ShowDialog();
        }
        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas appPersonas = new Personas(_context);
            appPersonas.ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            AlumnoInscripciones appInscripciones = new AlumnoInscripciones(_context);
            appInscripciones.ShowDialog();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            RegistrarNotas appNotas = new RegistrarNotas(_context);
            appNotas.ShowDialog();
        }
    }
}
