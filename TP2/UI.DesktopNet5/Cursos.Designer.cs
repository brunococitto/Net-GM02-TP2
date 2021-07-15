
namespace UI.Desktop
{
    partial class Cursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cursos));
            this.tscMaterias = new System.Windows.Forms.ToolStripContainer();
            this.tlMaterias = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_calendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tscMaterias.ContentPanel.SuspendLayout();
            this.tscMaterias.TopToolStripPanel.SuspendLayout();
            this.tscMaterias.SuspendLayout();
            this.tlMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.tsCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscMaterias
            // 
            // 
            // tscMaterias.ContentPanel
            // 
            this.tscMaterias.ContentPanel.Controls.Add(this.tlMaterias);
            this.tscMaterias.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscMaterias.ContentPanel.Size = new System.Drawing.Size(602, 410);
            this.tscMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMaterias.Location = new System.Drawing.Point(0, 0);
            this.tscMaterias.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscMaterias.Name = "tscMaterias";
            this.tscMaterias.Size = new System.Drawing.Size(602, 435);
            this.tscMaterias.TabIndex = 0;
            this.tscMaterias.Text = "toolStripContainer1";
            // 
            // tscMaterias.TopToolStripPanel
            // 
            this.tscMaterias.TopToolStripPanel.Controls.Add(this.tsCursos);
            // 
            // tlMaterias
            // 
            this.tlMaterias.ColumnCount = 2;
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMaterias.Controls.Add(this.dgvCursos, 0, 0);
            this.tlMaterias.Controls.Add(this.btnActualizar, 0, 1);
            this.tlMaterias.Controls.Add(this.btnSalir, 1, 1);
            this.tlMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMaterias.Location = new System.Drawing.Point(0, 0);
            this.tlMaterias.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlMaterias.Name = "tlMaterias";
            this.tlMaterias.RowCount = 2;
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMaterias.Size = new System.Drawing.Size(602, 410);
            this.tlMaterias.TabIndex = 0;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeColumns = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.desc_curso,
            this.desc_materia,
            this.desc_comision,
            this.anio_calendario,
            this.cupo});
            this.tlMaterias.SetColumnSpan(this.dgvCursos, 2);
            this.dgvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursos.Location = new System.Drawing.Point(4, 3);
            this.dgvCursos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.Size = new System.Drawing.Size(594, 371);
            this.dgvCursos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(414, 380);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 27);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(510, 380);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 27);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsCursos
            // 
            this.tsCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsCursos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsCursos.Location = new System.Drawing.Point(3, 0);
            this.tsCursos.Name = "tsCursos";
            this.tsCursos.Size = new System.Drawing.Size(72, 25);
            this.tsCursos.TabIndex = 0;
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
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // desc_curso
            // 
            this.desc_curso.DataPropertyName = "DescripcionCur";
            this.desc_curso.HeaderText = "Descripcion";
            this.desc_curso.Name = "desc_curso";
            this.desc_curso.ReadOnly = true;
            // 
            // desc_materia
            // 
            this.desc_materia.DataPropertyName = "DescripcionMat";
            this.desc_materia.HeaderText = "Materia";
            this.desc_materia.Name = "desc_materia";
            this.desc_materia.Width = 150;
            // 
            // desc_comision
            // 
            this.desc_comision.DataPropertyName = "DescripcionCom";
            this.desc_comision.HeaderText = "Comision";
            this.desc_comision.Name = "desc_comision";
            // 
            // anio_calendario
            // 
            this.anio_calendario.DataPropertyName = "AnoCalendario";
            this.anio_calendario.HeaderText = "Anio Calendario";
            this.anio_calendario.Name = "anio_calendario";
            // 
            // cupo
            // 
            this.cupo.DataPropertyName = "Cupo";
            this.cupo.HeaderText = "Cupo";
            this.cupo.Name = "cupo";
            this.cupo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cupo.Width = 300;
            // 
            // Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 435);
            this.Controls.Add(this.tscMaterias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Cursos";
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.Cursos_Load);
            this.tscMaterias.ContentPanel.ResumeLayout(false);
            this.tscMaterias.TopToolStripPanel.ResumeLayout(false);
            this.tscMaterias.TopToolStripPanel.PerformLayout();
            this.tscMaterias.ResumeLayout(false);
            this.tscMaterias.PerformLayout();
            this.tlMaterias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.tsCursos.ResumeLayout(false);
            this.tsCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscMaterias;
        private System.Windows.Forms.TableLayoutPanel tlMaterias;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsCursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_calendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cupo;
    }
}

