using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            this.tlMain.Visible = false;
            formLogin appLogin = new formLogin(_context);
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            this.lblMain.Text = $"Bienvenido: {Singleton.getInstance().PersonaLogged.Legajo} - {Singleton.getInstance().PersonaLogged.Apellido}, {Singleton.getInstance().PersonaLogged.Nombre}";
            this.lblMain.Visible = true;
            switch (Singleton.getInstance().PersonaLogged.TipoPersona)
            {
                case Business.Entities.Persona.TiposPersona.Alumno:
                    this.mnuABMC.Visible = false;
                    this.mnuInscripciones.Visible = false;
                    this.mnuRegistroNotas.Visible = false;
                    this.mnuAsignarProfesores.Visible = false;
                    this.mnuEstadoAcademico.Visible = true;
                    break;
                case Business.Entities.Persona.TiposPersona.Profesor:
                    this.mnuABMC.Visible = false;
                    this.mnuInscripciones.Visible = false;
                    this.mnuAsignarProfesores.Visible = false;
                    this.mnuRegistroNotas.Visible = true;
                    this.mnuEstadoAcademico.Visible = false;
                    break;
                case Business.Entities.Persona.TiposPersona.Administrativo:
                    this.mnuABMC.Visible = true;
                    this.mnuInscripciones.Visible = true;
                    this.mnuAsignarProfesores.Visible = true;
                    this.mnuRegistroNotas.Visible = false;
                    this.mnuEstadoAcademico.Visible = false;
                    break;
            }
            this.tlMain.Visible = true;
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            resetPanelPrincipal();
            this.lblMain.Visible = false;
            this.formMain_Shown(sender, e);
        }
        private void setForm(Form form)
        {
            resetPanelPrincipal();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.pnlPrincipal.Tag = form;
            this.pnlPrincipal.Controls.Add(form);
            this.lblMain.Visible = false;
            this.tsbExportar.Enabled = true;
            form.Show();
        }
        private void resetPanelPrincipal()
        {
            if (this.pnlPrincipal.Controls.Count > 0)
            {
                this.pnlPrincipal.Controls[0].Dispose();
            }
            this.lblMain.Visible = true;
            Singleton.getInstance().DgvActual = null;
            Singleton.getInstance().ModuloActual = null;
            this.tsbExportar.Enabled = false;
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
        private void asignarProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setForm(new DocenteCursos(_context));
        }

        private void estadoAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setForm(new EstadoAcademico(_context));
        }

        private void tsbHome_Click(object sender, EventArgs e)
        {
            resetPanelPrincipal();
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            if (Singleton.getInstance().DgvActual != null && Singleton.getInstance().DgvActual.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Reporte de {Singleton.getInstance().ModuloActual} - {DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("No fue posible escribir el archivo en el disco." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(Singleton.getInstance().DgvActual.Columns.Count - 1);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in Singleton.getInstance().DgvActual.Columns)
                            {
                                if (column.Visible == true)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }                                
                            }

                            foreach (DataGridViewRow row in Singleton.getInstance().DgvActual.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Displayed == true)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                Paragraph p = new Paragraph();
                                p.Alignment = Element.ALIGN_CENTER;
                                p.Add($"Reporte de {Singleton.getInstance().ModuloActual}");
                                pdfDoc.Add(p);
                                pdfDoc.Add(Chunk.NEWLINE);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Reporte exportado exitosamente", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay registros para exportar", "Info");
            }
        }
    }
}
