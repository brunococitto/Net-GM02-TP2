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
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso CursoActual { set; get; }
        private readonly ComisionLogic _comisionLogic;
        private readonly MateriaLogic _materiaLogic;
        private readonly CursoLogic _cursoLogic;
        public CursoDesktop(AcademyContext context)
        {
            InitializeComponent();
            _comisionLogic = new ComisionLogic(new ComisionAdapter(context));
            _materiaLogic = new MateriaLogic(new MateriaAdapter(context));
            _cursoLogic = new CursoLogic(new CursoAdapter(context));
        }
        // Este es el constructor cuando se da de alta alta, ya que solo tiene un arg
        public CursoDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // Cargo las materias para mostrarlos en el combobox
            List<Materia> listaMaterias = _materiaLogic.GetAll();
            this.cbMateria.DataSource = listaMaterias;
            // selecciono la materia de la posicion 0 como para seleccionar algo
            this.cbMateria.SelectedIndex = 0;
            // Modos = modo;
            // Cargo las comisiones para mostrarlos en el combobox
            List<Comision> listaComisiones = _comisionLogic.GetAll();
            this.cbComision.DataSource = listaComisiones;
            // selecciono la comision de la posicion 0 como para seleccionar algo
            this.cbComision.SelectedIndex = 0;
        }
        // Este es el constructor cuando se edita o elimina algo, ya que tiene dos args
        public CursoDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            CursoActual = _cursoLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;
            this.txtAnoCalendario.Text = this.CursoActual.AnoCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            // Acá cuando cargo el curso tengo que buscar la materia asignada
            Materia materiaActualCurso = _materiaLogic.GetOne(CursoActual.IDMateria);
            // A su vez tengo que cargar las otras materias por si quiero seleccionar otra
            List<Materia> materias = _materiaLogic.GetAll();
            // seteo como datasource del combobox la lista de materias anteriores
            this.cbMateria.DataSource = materias;
            // ahora tengo que seleccionar la materia correspondiente a el curso
            this.cbMateria.SelectedIndex = cbMateria.FindStringExact(materiaActualCurso.Descripcion);
            // Acá cuando cargo el curso tengo que buscar la materia asignada
            Comision comisionActualCurso = _comisionLogic.GetOne(CursoActual.IDComision);
            // A su vez tengo que cargar las otras materias por si quiero seleccionar otra
            List<Comision> comisiones = _comisionLogic.GetAll();
            // seteo como datasource del combobox la lista de materias anteriores
            this.cbComision.DataSource = comisiones;
            // ahora tengo que seleccionar la materia correspondiente a el curso
            this.cbComision.SelectedIndex = cbComision.FindStringExact(comisionActualCurso.Descripcion);

            switch (this.Modos)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.cbMateria.Enabled = false;
                    this.cbComision.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.txtAnoCalendario.Enabled = false;
                    this.txtCupo.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    this.cbMateria.Enabled = false;
                    this.cbComision.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.txtAnoCalendario.Enabled = false;
                    this.txtCupo.Enabled = false;
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                CursoActual = new Curso();
                CursoActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                CursoActual.IDMateria = (int)this.cbMateria.SelectedValue;
                CursoActual.IDComision = (int)this.cbComision.SelectedValue;
                CursoActual.AnoCalendario = Convert.ToInt32(this.txtAnoCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
            }
            if (Modos == ModoForm.Modificacion)
            {
                CursoActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                CursoActual.IDMateria = (int)this.cbMateria.SelectedValue;
                CursoActual.IDComision = (int)this.cbComision.SelectedValue;
                CursoActual.AnoCalendario = Convert.ToInt32(this.txtAnoCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            _cursoLogic.Save(CursoActual);
        }
        public override bool Validar()
        {
            try
            {
                Validaciones.ValidarNulo(this.txtDescripcion.Text, "descripcón");
                Validaciones.ValidarNulo(this.txtAnoCalendario.Text, "año calendario");
                Validaciones.ValidarNulo(this.txtCupo.Text, "cupo");
                Validaciones.ValidarNumero(this.txtAnoCalendario.Text, "año calendario");
                Validaciones.ValidarLetrasNumeros(this.txtDescripcion.Text, "descripcón");
                Validaciones.ValidarNumero(this.txtCupo.Text, "cupo");
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modos)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Baja:
                    Eliminar();
                    Close();
                    break;
                case ModoForm.Consulta:
                    Close();
                    break;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public virtual void Eliminar()
        {
            _cursoLogic.Delete(CursoActual.ID);
        }
    }
}
