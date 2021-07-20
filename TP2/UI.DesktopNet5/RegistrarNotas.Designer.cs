
namespace UI.Desktop
{
    partial class RegistrarNotas
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
            this.tscRegistrarNotas = new System.Windows.Forms.ToolStripContainer();
            this.gbModificarInscripcion = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.lblSeleccionarCurso = new System.Windows.Forms.Label();
            this.cbCursos = new System.Windows.Forms.ComboBox();
            this.dgvRegistrarNotas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tscRegistrarNotas.ContentPanel.SuspendLayout();
            this.tscRegistrarNotas.SuspendLayout();
            this.gbModificarInscripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrarNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // tscRegistrarNotas
            // 
            // 
            // tscRegistrarNotas.ContentPanel
            // 
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.gbModificarInscripcion);
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.lblSeleccionarCurso);
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.cbCursos);
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.dgvRegistrarNotas);
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.btnSalir);
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.btnActualizar);
            this.tscRegistrarNotas.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscRegistrarNotas.ContentPanel.Size = new System.Drawing.Size(837, 379);
            this.tscRegistrarNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscRegistrarNotas.Location = new System.Drawing.Point(0, 0);
            this.tscRegistrarNotas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscRegistrarNotas.Name = "tscRegistrarNotas";
            this.tscRegistrarNotas.Size = new System.Drawing.Size(837, 379);
            this.tscRegistrarNotas.TabIndex = 0;
            this.tscRegistrarNotas.Text = "toolStripContainer1";
            // 
            // gbModificarInscripcion
            // 
            this.gbModificarInscripcion.Controls.Add(this.lblNombre);
            this.gbModificarInscripcion.Controls.Add(this.lblNota);
            this.gbModificarInscripcion.Controls.Add(this.txtNota);
            this.gbModificarInscripcion.Controls.Add(this.btnGuardar);
            this.gbModificarInscripcion.Controls.Add(this.txtNombre);
            this.gbModificarInscripcion.Controls.Add(this.lblApellido);
            this.gbModificarInscripcion.Controls.Add(this.txtApellido);
            this.gbModificarInscripcion.Controls.Add(this.lblCondicion);
            this.gbModificarInscripcion.Controls.Add(this.txtCondicion);
            this.gbModificarInscripcion.Location = new System.Drawing.Point(13, 242);
            this.gbModificarInscripcion.Name = "gbModificarInscripcion";
            this.gbModificarInscripcion.Size = new System.Drawing.Size(449, 109);
            this.gbModificarInscripcion.TabIndex = 14;
            this.gbModificarInscripcion.TabStop = false;
            this.gbModificarInscripcion.Text = "Modificar inscripcion";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNota
            // 
            this.lblNota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(250, 48);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(33, 15);
            this.lblNota.TabIndex = 11;
            this.lblNota.Text = "Nota";
            this.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(289, 45);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(42, 23);
            this.txtNota.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(14, 74);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 29);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(74, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(152, 23);
            this.txtNombre.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(232, 19);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(289, 16);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(152, 23);
            this.txtApellido.TabIndex = 8;
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(6, 48);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(62, 15);
            this.lblCondicion.TabIndex = 9;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Location = new System.Drawing.Point(74, 45);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(152, 23);
            this.txtCondicion.TabIndex = 10;
            // 
            // lblSeleccionarCurso
            // 
            this.lblSeleccionarCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeleccionarCurso.AutoSize = true;
            this.lblSeleccionarCurso.Location = new System.Drawing.Point(12, 11);
            this.lblSeleccionarCurso.Name = "lblSeleccionarCurso";
            this.lblSeleccionarCurso.Size = new System.Drawing.Size(38, 15);
            this.lblSeleccionarCurso.TabIndex = 4;
            this.lblSeleccionarCurso.Text = "Curso";
            this.lblSeleccionarCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCursos
            // 
            this.cbCursos.DisplayMember = "Descripcion";
            this.cbCursos.FormattingEnabled = true;
            this.cbCursos.Location = new System.Drawing.Point(80, 8);
            this.cbCursos.Name = "cbCursos";
            this.cbCursos.Size = new System.Drawing.Size(750, 23);
            this.cbCursos.TabIndex = 3;
            this.cbCursos.ValueMember = "ID";
            this.cbCursos.SelectionChangeCommitted += new System.EventHandler(this.cbCursos_SelectionChangeCommitted);
            // 
            // dgvRegistrarNotas
            // 
            this.dgvRegistrarNotas.AllowUserToAddRows = false;
            this.dgvRegistrarNotas.AllowUserToDeleteRows = false;
            this.dgvRegistrarNotas.AllowUserToResizeColumns = false;
            this.dgvRegistrarNotas.AllowUserToResizeRows = false;
            this.dgvRegistrarNotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvRegistrarNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrarNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.legajo,
            this.nombre,
            this.apellido,
            this.condicion,
            this.nota});
            this.dgvRegistrarNotas.Location = new System.Drawing.Point(13, 49);
            this.dgvRegistrarNotas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvRegistrarNotas.MultiSelect = false;
            this.dgvRegistrarNotas.Name = "dgvRegistrarNotas";
            this.dgvRegistrarNotas.Size = new System.Drawing.Size(818, 187);
            this.dgvRegistrarNotas.TabIndex = 0;
            this.dgvRegistrarNotas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegistrarNotas_RowHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            // condicion
            // 
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condicion";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Nota";
            this.nota.Name = "nota";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(742, 242);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 29);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(646, 242);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 29);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // RegistrarNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 379);
            this.Controls.Add(this.tscRegistrarNotas);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RegistrarNotas";
            this.Text = "RegistrarNotas";
            this.Load += new System.EventHandler(this.RegistrarNotas_Load);
            this.tscRegistrarNotas.ContentPanel.ResumeLayout(false);
            this.tscRegistrarNotas.ContentPanel.PerformLayout();
            this.tscRegistrarNotas.ResumeLayout(false);
            this.tscRegistrarNotas.PerformLayout();
            this.gbModificarInscripcion.ResumeLayout(false);
            this.gbModificarInscripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrarNotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscRegistrarNotas;
        private System.Windows.Forms.DataGridView dgvRegistrarNotas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.Label lblSeleccionarCurso;
        private System.Windows.Forms.GroupBox gbModificarInscripcion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
    }
}

