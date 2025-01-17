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

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        private readonly ComisionLogic _comisionLogic;
        private readonly PlanLogic _planLogic;
        private readonly AcademyContext _context;
        public Comisiones(AcademyContext context)
        {
            InitializeComponent();
            _comisionLogic = new ComisionLogic(new ComisionAdapter(context));
            _planLogic = new PlanLogic(new PlanAdapter(context));
            _context = context;
        }
        private void Comisiones_Load(object sender, EventArgs e)
        {
            Singleton.getInstance().DgvActual = this.dgvComisiones;
            Singleton.getInstance().ModuloActual = "Comisiones";
            this.Listar();
        }
        public void Listar()
        {
            try
            {
                List<Plan> planes = _planLogic.GetAll();
                List<Comision> comisiones = _comisionLogic.GetAll();
                var consulta =
                                from p in planes
                                join c in comisiones
                                on p.ID equals c.IDPlan
                                select new
                                {
                                    ID = c.ID,
                                    Descripcion = c.Descripcion,
                                    AnoEspecialidad = c.AnoEspecialidad,
                                    Plan = p.Descripcion
                                };
                this.dgvComisiones.DataSource = consulta.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvComisiones.AutoGenerateColumns = false;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop formComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta, _context);
            formComision.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            {
                if (this.dgvComisiones.SelectedRows.Count > 0)
                {
                    int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["ID"].Value;
                    ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion, _context);
                    formComision.ShowDialog();
                    this.Listar();
                }
                else
                {
                    MessageBox.Show("Seleccionar una fila en la grilla para poder editar");
                }

            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvComisiones.SelectedRows[0].Cells["ID"].Value;
                ComisionesDesktop formComision = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja, _context);
                formComision.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccionar una fila en la grilla para poder eliminar");
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
