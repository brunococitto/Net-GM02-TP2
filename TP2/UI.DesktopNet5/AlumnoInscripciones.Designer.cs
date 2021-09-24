
namespace UI.Desktop
{
    partial class AlumnoInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnoInscripciones));
            this.tscAlumnoInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlAlumnoInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnoInscripciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsAlumnoInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscAlumnoInscripciones.ContentPanel.SuspendLayout();
            this.tscAlumnoInscripciones.TopToolStripPanel.SuspendLayout();
            this.tscAlumnoInscripciones.SuspendLayout();
            this.tlAlumnoInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoInscripciones)).BeginInit();
            this.tsAlumnoInscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscAlumnoInscripciones
            // 
            // 
            // tscAlumnoInscripciones.ContentPanel
            // 
            this.tscAlumnoInscripciones.ContentPanel.Controls.Add(this.tlAlumnoInscripciones);
            this.tscAlumnoInscripciones.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscAlumnoInscripciones.ContentPanel.Size = new System.Drawing.Size(933, 410);
            this.tscAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscAlumnoInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tscAlumnoInscripciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscAlumnoInscripciones.Name = "tscAlumnoInscripciones";
            this.tscAlumnoInscripciones.Size = new System.Drawing.Size(933, 435);
            this.tscAlumnoInscripciones.TabIndex = 0;
            this.tscAlumnoInscripciones.Text = "toolStripContainer1";
            // 
            // tscAlumnoInscripciones.TopToolStripPanel
            // 
            this.tscAlumnoInscripciones.TopToolStripPanel.Controls.Add(this.tsAlumnoInscripciones);
            // 
            // tlAlumnoInscripciones
            // 
            this.tlAlumnoInscripciones.ColumnCount = 2;
            this.tlAlumnoInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnoInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnoInscripciones.Controls.Add(this.dgvAlumnoInscripciones, 0, 0);
            this.tlAlumnoInscripciones.Controls.Add(this.btnActualizar, 1, 1);
            this.tlAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnoInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnoInscripciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlAlumnoInscripciones.Name = "tlAlumnoInscripciones";
            this.tlAlumnoInscripciones.RowCount = 2;
            this.tlAlumnoInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnoInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripciones.Size = new System.Drawing.Size(933, 410);
            this.tlAlumnoInscripciones.TabIndex = 0;
            // 
            // dgvAlumnoInscripciones
            // 
            this.dgvAlumnoInscripciones.AllowUserToAddRows = false;
            this.dgvAlumnoInscripciones.AllowUserToDeleteRows = false;
            this.dgvAlumnoInscripciones.AllowUserToResizeColumns = false;
            this.dgvAlumnoInscripciones.AllowUserToResizeRows = false;
            this.dgvAlumnoInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnoInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.legajo,
            this.nombre,
            this.apellido,
            this.curso,
            this.condicion,
            this.nota});
            this.tlAlumnoInscripciones.SetColumnSpan(this.dgvAlumnoInscripciones, 2);
            this.dgvAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnoInscripciones.Location = new System.Drawing.Point(4, 3);
            this.dgvAlumnoInscripciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvAlumnoInscripciones.MultiSelect = false;
            this.dgvAlumnoInscripciones.Name = "dgvAlumnoInscripciones";
            this.dgvAlumnoInscripciones.Size = new System.Drawing.Size(925, 371);
            this.dgvAlumnoInscripciones.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // legajo
            // 
            this.legajo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.legajo.DataPropertyName = "Legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            this.legajo.Width = 67;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 76;
            // 
            // apellido
            // 
            this.apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Width = 76;
            // 
            // curso
            // 
            this.curso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.curso.DataPropertyName = "Curso";
            this.curso.HeaderText = "Curso";
            this.curso.Name = "curso";
            this.curso.ReadOnly = true;
            this.curso.Width = 63;
            // 
            // condicion
            // 
            this.condicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condicion";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            this.condicion.Width = 87;
            // 
            // nota
            // 
            this.nota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            this.nota.Width = 58;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(841, 380);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 27);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tsAlumnoInscripciones
            // 
            this.tsAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAlumnoInscripciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAlumnoInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsAlumnoInscripciones.Location = new System.Drawing.Point(3, 0);
            this.tsAlumnoInscripciones.Name = "tsAlumnoInscripciones";
            this.tsAlumnoInscripciones.Size = new System.Drawing.Size(103, 25);
            this.tsAlumnoInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Enabled = false;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton1";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Visible = false;
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // AlumnoInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 435);
            this.Controls.Add(this.tscAlumnoInscripciones);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AlumnoInscripciones";
            this.Text = "AlumnoInscripciones";
            this.Load += new System.EventHandler(this.AlumnoInscripciones_Load);
            this.tscAlumnoInscripciones.ContentPanel.ResumeLayout(false);
            this.tscAlumnoInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tscAlumnoInscripciones.TopToolStripPanel.PerformLayout();
            this.tscAlumnoInscripciones.ResumeLayout(false);
            this.tscAlumnoInscripciones.PerformLayout();
            this.tlAlumnoInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoInscripciones)).EndInit();
            this.tsAlumnoInscripciones.ResumeLayout(false);
            this.tsAlumnoInscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscAlumnoInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlAlumnoInscripciones;
        private System.Windows.Forms.DataGridView dgvAlumnoInscripciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsAlumnoInscripciones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
    }
}

