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
    public partial class EstadoAcademico : Form
    {
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly AcademyContext _context;
        public EstadoAcademico(AcademyContext context)
        {
            InitializeComponent();
            _alumnoInscripcionLogic = new AlumnoInscripcionLogic(new AlumnoInscripcionAdapter(context));
            _context = context;
        }
        private void EstadoAcademico_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            this.dgvEstadoAcademico.DataSource = _alumnoInscripcionLogic.GetEstadoAcademico(Singleton.getInstance().PersonaLogged.ID);
            this.dgvEstadoAcademico.AutoGenerateColumns = false;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
