﻿using System;
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
using FluentValidation;
using FluentValidation.Results;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        private readonly PlanLogic _planLogic;
        private readonly EspecialidadLogic _especialidadLogic;
        public Plan PlanActual { set; get; }
        public PlanDesktop(AcademyContext context)
        {
            InitializeComponent();
            _planLogic = new PlanLogic(new PlanAdapter(context));
            _especialidadLogic = new EspecialidadLogic(new EspecialidadAdapter(context));
        }
        // Este es el constructor cuando se da de alta alta, ya que solo tiene un arg
        public PlanDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            // Cargo las especialidades para mostrarlas en el combobox
            try
            {
                List<Especialidad> listaEsp = _especialidadLogic.GetAll();
                this.cbEspecialidad.DataSource = listaEsp;
                // this.cbEspecialidad.DataSource = listToDataTable(listaEsp).DefaultView;
                this.cbEspecialidad.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Este es el constructor cuando se edita o elimina algo, ya que tiene dos args
        public PlanDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                PlanActual = _planLogic.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            // Acá cuando cargo el plan tengo que buscar la especialidad asignada al plan
            try
            {
                Especialidad espActualPlan = _especialidadLogic.GetOne(PlanActual.IDEspecialidad);
                // A su vez tengo que cargar las otras especialidades por si quiero seleccionar otra
                List<Especialidad> especialidades = _especialidadLogic.GetAll();
                // seteo como datasource del combobox la lista de especialidades anteriores
                this.cbEspecialidad.DataSource = especialidades;
                // ahora tengo que seleccionar la especialidad correspondiente al plan actual
                this.cbEspecialidad.SelectedIndex = cbEspecialidad.FindStringExact(espActualPlan.Descripcion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    this.cbEspecialidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    this.cbEspecialidad.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                PlanActual.IDEspecialidad = (int)this.cbEspecialidad.SelectedValue;
            }
            if (Modos == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                // Recordar que el value member del combo es el ID de especialidad
                PlanActual.IDEspecialidad = (int)this.cbEspecialidad.SelectedValue;
            }
            switch (Modos)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                if (Validar())
                {
                    _planLogic.Save(PlanActual);
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new PlanValidator().Validate(PlanActual);
            if (!result.IsValid)
            {
                string notificacion = string.Join(Environment.NewLine, result.Errors);
                MessageBox.Show(notificacion);
                return false;
            }
            return true;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modos)
            {
                case ModoForm.Alta:
                    {
                        GuardarCambios();
                    };
                    break;
                case ModoForm.Modificacion:
                    {
                        GuardarCambios();
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
            try
            {
                _planLogic.Delete(PlanActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
