
namespace UI.Desktop
{
    partial class DocenteCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocenteCursos));
            this.tscDocenteCursos = new System.Windows.Forms.ToolStripContainer();
            this.tlDocenteCursos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocenteCursos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsDocenteCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscDocenteCursos.ContentPanel.SuspendLayout();
            this.tscDocenteCursos.TopToolStripPanel.SuspendLayout();
            this.tscDocenteCursos.SuspendLayout();
            this.tlDocenteCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteCursos)).BeginInit();
            this.tsDocenteCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscDocenteCursos
            // 
            // 
            // tscDocenteCursos.ContentPanel
            // 
            this.tscDocenteCursos.ContentPanel.Controls.Add(this.tlDocenteCursos);
            this.tscDocenteCursos.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscDocenteCursos.ContentPanel.Size = new System.Drawing.Size(933, 410);
            this.tscDocenteCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscDocenteCursos.Location = new System.Drawing.Point(0, 0);
            this.tscDocenteCursos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscDocenteCursos.Name = "tscDocenteCursos";
            this.tscDocenteCursos.Size = new System.Drawing.Size(933, 435);
            this.tscDocenteCursos.TabIndex = 0;
            this.tscDocenteCursos.Text = "toolStripContainer1";
            // 
            // tscDocenteCursos.TopToolStripPanel
            // 
            this.tscDocenteCursos.TopToolStripPanel.Controls.Add(this.tsDocenteCursos);
            // 
            // tlDocenteCursos
            // 
            this.tlDocenteCursos.ColumnCount = 2;
            this.tlDocenteCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocenteCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocenteCursos.Controls.Add(this.dgvDocenteCursos, 0, 0);
            this.tlDocenteCursos.Controls.Add(this.btnActualizar, 1, 1);
            this.tlDocenteCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocenteCursos.Location = new System.Drawing.Point(0, 0);
            this.tlDocenteCursos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlDocenteCursos.Name = "tlDocenteCursos";
            this.tlDocenteCursos.RowCount = 2;
            this.tlDocenteCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocenteCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocenteCursos.Size = new System.Drawing.Size(933, 410);
            this.tlDocenteCursos.TabIndex = 0;
            // 
            // dgvDocenteCursos
            // 
            this.dgvDocenteCursos.AllowUserToAddRows = false;
            this.dgvDocenteCursos.AllowUserToDeleteRows = false;
            this.dgvDocenteCursos.AllowUserToResizeColumns = false;
            this.dgvDocenteCursos.AllowUserToResizeRows = false;
            this.dgvDocenteCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocenteCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.legajo,
            this.nombre,
            this.apellido,
            this.curso,
            this.cargo});
            this.tlDocenteCursos.SetColumnSpan(this.dgvDocenteCursos, 2);
            this.dgvDocenteCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocenteCursos.Location = new System.Drawing.Point(4, 3);
            this.dgvDocenteCursos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDocenteCursos.MultiSelect = false;
            this.dgvDocenteCursos.Name = "dgvDocenteCursos";
            this.dgvDocenteCursos.Size = new System.Drawing.Size(925, 371);
            this.dgvDocenteCursos.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // legajo
            // 
            this.legajo.DataPropertyName = "Legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // curso
            // 
            this.curso.DataPropertyName = "Curso";
            this.curso.HeaderText = "Curso";
            this.curso.Name = "curso";
            this.curso.ReadOnly = true;
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "Cargo";
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
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
            // tsDocenteCursos
            // 
            this.tsDocenteCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocenteCursos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDocenteCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsDocenteCursos.Location = new System.Drawing.Point(3, 0);
            this.tsDocenteCursos.Name = "tsDocenteCursos";
            this.tsDocenteCursos.Size = new System.Drawing.Size(72, 25);
            this.tsDocenteCursos.TabIndex = 0;
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
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton1";
            this.tsbEditar.ToolTipText = "Editar";
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
            // DocenteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 435);
            this.Controls.Add(this.tscDocenteCursos);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DocenteCursos";
            this.Text = "DocenteCursos";
            this.Load += new System.EventHandler(this.DocenteCursos_Load);
            this.tscDocenteCursos.ContentPanel.ResumeLayout(false);
            this.tscDocenteCursos.TopToolStripPanel.ResumeLayout(false);
            this.tscDocenteCursos.TopToolStripPanel.PerformLayout();
            this.tscDocenteCursos.ResumeLayout(false);
            this.tscDocenteCursos.PerformLayout();
            this.tlDocenteCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteCursos)).EndInit();
            this.tsDocenteCursos.ResumeLayout(false);
            this.tsDocenteCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscDocenteCursos;
        private System.Windows.Forms.TableLayoutPanel tlDocenteCursos;
        private System.Windows.Forms.DataGridView dgvDocenteCursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsDocenteCursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
    }
}

