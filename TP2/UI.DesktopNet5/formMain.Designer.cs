
namespace UI.Desktop
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuABMC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistroNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAsignarProfesores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstadoAcademico = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblMain = new System.Windows.Forms.Label();
            this.tsHome = new System.Windows.Forms.ToolStrip();
            this.tsbHome = new System.Windows.Forms.ToolStripButton();
            this.tsbExportar = new System.Windows.Forms.ToolStripButton();
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.mnsPrincipal.SuspendLayout();
            this.tsHome.SuspendLayout();
            this.tlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mnsPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuABMC,
            this.mnuInscripciones,
            this.mnuRegistroNotas,
            this.mnuAsignarProfesores,
            this.mnuEstadoAcademico});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnsPrincipal.Size = new System.Drawing.Size(1014, 25);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrarSesion,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 21);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(142, 22);
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(142, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuABMC
            // 
            this.mnuABMC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComisiones,
            this.mnuCursos,
            this.mnuEspecialidades,
            this.mnuMaterias,
            this.mnuModulos,
            this.mnuPersonas,
            this.mnuPlanes,
            this.mnuUsuarios});
            this.mnuABMC.Name = "mnuABMC";
            this.mnuABMC.Size = new System.Drawing.Size(53, 21);
            this.mnuABMC.Text = "ABMC";
            // 
            // mnuComisiones
            // 
            this.mnuComisiones.Name = "mnuComisiones";
            this.mnuComisiones.Size = new System.Drawing.Size(150, 22);
            this.mnuComisiones.Text = "Comisiones";
            this.mnuComisiones.Click += new System.EventHandler(this.mnuComisiones_Click);
            // 
            // mnuCursos
            // 
            this.mnuCursos.Name = "mnuCursos";
            this.mnuCursos.Size = new System.Drawing.Size(150, 22);
            this.mnuCursos.Text = "Cursos";
            this.mnuCursos.Click += new System.EventHandler(this.mnuCursos_Click);
            // 
            // mnuEspecialidades
            // 
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(150, 22);
            this.mnuEspecialidades.Text = "Especialidades";
            this.mnuEspecialidades.Click += new System.EventHandler(this.mnuEspecialidades_Click);
            // 
            // mnuMaterias
            // 
            this.mnuMaterias.Name = "mnuMaterias";
            this.mnuMaterias.Size = new System.Drawing.Size(150, 22);
            this.mnuMaterias.Text = "Materias";
            this.mnuMaterias.Click += new System.EventHandler(this.mnuMaterias_Click);
            // 
            // mnuModulos
            // 
            this.mnuModulos.Name = "mnuModulos";
            this.mnuModulos.Size = new System.Drawing.Size(150, 22);
            this.mnuModulos.Text = "Modulos";
            this.mnuModulos.Click += new System.EventHandler(this.mnuModulos_Click);
            // 
            // mnuPersonas
            // 
            this.mnuPersonas.Name = "mnuPersonas";
            this.mnuPersonas.Size = new System.Drawing.Size(150, 22);
            this.mnuPersonas.Text = "Personas";
            this.mnuPersonas.Click += new System.EventHandler(this.mnuPersonas_Click);
            // 
            // mnuPlanes
            // 
            this.mnuPlanes.Name = "mnuPlanes";
            this.mnuPlanes.Size = new System.Drawing.Size(150, 22);
            this.mnuPlanes.Text = "Planes";
            this.mnuPlanes.Click += new System.EventHandler(this.mnuPlanes_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(150, 22);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuInscripciones
            // 
            this.mnuInscripciones.Name = "mnuInscripciones";
            this.mnuInscripciones.Size = new System.Drawing.Size(88, 21);
            this.mnuInscripciones.Text = "Inscripciones";
            this.mnuInscripciones.Click += new System.EventHandler(this.mnuInscripciones_Click);
            // 
            // mnuRegistroNotas
            // 
            this.mnuRegistroNotas.Name = "mnuRegistroNotas";
            this.mnuRegistroNotas.Size = new System.Drawing.Size(94, 21);
            this.mnuRegistroNotas.Text = "Registro notas";
            this.mnuRegistroNotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuRegistroNotas.Click += new System.EventHandler(this.mnuRegistroNotas_Click);
            // 
            // mnuAsignarProfesores
            // 
            this.mnuAsignarProfesores.Name = "mnuAsignarProfesores";
            this.mnuAsignarProfesores.Size = new System.Drawing.Size(117, 21);
            this.mnuAsignarProfesores.Text = "Asignar profesores";
            this.mnuAsignarProfesores.Click += new System.EventHandler(this.asignarProfesoresToolStripMenuItem_Click);
            // 
            // mnuEstadoAcademico
            // 
            this.mnuEstadoAcademico.Name = "mnuEstadoAcademico";
            this.mnuEstadoAcademico.Size = new System.Drawing.Size(115, 21);
            this.mnuEstadoAcademico.Text = "Estado academico";
            this.mnuEstadoAcademico.Click += new System.EventHandler(this.estadoAcademicoToolStripMenuItem_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tlMain.SetColumnSpan(this.pnlPrincipal, 2);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 28);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1088, 488);
            this.pnlPrincipal.TabIndex = 22;
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMain.Location = new System.Drawing.Point(12, 38);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(45, 21);
            this.lblMain.TabIndex = 0;
            this.lblMain.Text = "Texto";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMain.Visible = false;
            // 
            // tsHome
            // 
            this.tsHome.Dock = System.Windows.Forms.DockStyle.None;
            this.tsHome.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHome,
            this.tsbExportar});
            this.tsHome.Location = new System.Drawing.Point(1014, 0);
            this.tsHome.Name = "tsHome";
            this.tsHome.Size = new System.Drawing.Size(80, 25);
            this.tsHome.TabIndex = 2;
            // 
            // tsbHome
            // 
            this.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHome.Image = ((System.Drawing.Image)(resources.GetObject("tsbHome.Image")));
            this.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHome.Name = "tsbHome";
            this.tsbHome.Size = new System.Drawing.Size(23, 22);
            this.tsbHome.Text = "toolStripButton1";
            this.tsbHome.ToolTipText = "Regresar al inicio";
            this.tsbHome.Click += new System.EventHandler(this.tsbHome_Click);
            // 
            // tsbExportar
            // 
            this.tsbExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportar.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportar.Image")));
            this.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportar.Name = "tsbExportar";
            this.tsbExportar.Size = new System.Drawing.Size(23, 22);
            this.tsbExportar.Text = "toolStripButton1";
            this.tsbExportar.ToolTipText = "Exportar lista como PDF";
            this.tsbExportar.Click += new System.EventHandler(this.tsbExportar_Click);
            // 
            // tlMain
            // 
            this.tlMain.ColumnCount = 2;
            this.tlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMain.Controls.Add(this.tsHome, 1, 0);
            this.tlMain.Controls.Add(this.pnlPrincipal, 0, 1);
            this.tlMain.Controls.Add(this.mnsPrincipal, 0, 0);
            this.tlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMain.Location = new System.Drawing.Point(0, 0);
            this.tlMain.Name = "tlMain";
            this.tlMain.RowCount = 2;
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMain.Size = new System.Drawing.Size(1094, 519);
            this.tlMain.TabIndex = 23;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 519);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.tlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMain";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.tsHome.ResumeLayout(false);
            this.tsHome.PerformLayout();
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuABMC;
        private System.Windows.Forms.ToolStripMenuItem mnuComisiones;
        private System.Windows.Forms.ToolStripMenuItem mnuCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuModulos;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonas;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripciones;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistroNotas;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuAsignarProfesores;
        private System.Windows.Forms.ToolStripMenuItem mnuEstadoAcademico;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.ToolStrip tsHome;
        private System.Windows.Forms.ToolStripButton tsbHome;
        private System.Windows.Forms.TableLayoutPanel tlMain;
        private System.Windows.Forms.ToolStripButton tsbExportar;
    }
}

