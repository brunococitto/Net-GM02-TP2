
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarNotas));
            this.tscRegistrarNotas = new System.Windows.Forms.ToolStripContainer();
            this.dgvRegistrarNotas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsRegistrarNotas = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tlRegistrarNotas = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tscRegistrarNotas.ContentPanel.SuspendLayout();
            this.tscRegistrarNotas.TopToolStripPanel.SuspendLayout();
            this.tscRegistrarNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrarNotas)).BeginInit();
            this.tsRegistrarNotas.SuspendLayout();
            this.tlRegistrarNotas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscRegistrarNotas
            // 
            // 
            // tscRegistrarNotas.ContentPanel
            // 
            this.tscRegistrarNotas.ContentPanel.Controls.Add(this.tlRegistrarNotas);
            this.tscRegistrarNotas.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscRegistrarNotas.ContentPanel.Size = new System.Drawing.Size(933, 410);
            this.tscRegistrarNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscRegistrarNotas.Location = new System.Drawing.Point(0, 0);
            this.tscRegistrarNotas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscRegistrarNotas.Name = "tscRegistrarNotas";
            this.tscRegistrarNotas.Size = new System.Drawing.Size(933, 435);
            this.tscRegistrarNotas.TabIndex = 0;
            this.tscRegistrarNotas.Text = "toolStripContainer1";
            // 
            // tscRegistrarNotas.TopToolStripPanel
            // 
            this.tscRegistrarNotas.TopToolStripPanel.Controls.Add(this.tsRegistrarNotas);
            // 
            // dgvRegistrarNotas
            // 
            this.dgvRegistrarNotas.AllowUserToAddRows = false;
            this.dgvRegistrarNotas.AllowUserToDeleteRows = false;
            this.dgvRegistrarNotas.AllowUserToResizeColumns = false;
            this.dgvRegistrarNotas.AllowUserToResizeRows = false;
            this.dgvRegistrarNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrarNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.legajo,
            this.nombre,
            this.apellido,
            this.curso,
            this.condicion,
            this.nota});
            this.tlRegistrarNotas.SetColumnSpan(this.dgvRegistrarNotas, 2);
            this.dgvRegistrarNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistrarNotas.Location = new System.Drawing.Point(4, 23);
            this.dgvRegistrarNotas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvRegistrarNotas.MultiSelect = false;
            this.dgvRegistrarNotas.Name = "dgvRegistrarNotas";
            this.dgvRegistrarNotas.Size = new System.Drawing.Size(925, 351);
            this.dgvRegistrarNotas.TabIndex = 0;
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
            // tsRegistrarNotas
            // 
            this.tsRegistrarNotas.Dock = System.Windows.Forms.DockStyle.None;
            this.tsRegistrarNotas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRegistrarNotas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsRegistrarNotas.Location = new System.Drawing.Point(3, 0);
            this.tsRegistrarNotas.Name = "tsRegistrarNotas";
            this.tsRegistrarNotas.Size = new System.Drawing.Size(72, 25);
            this.tsRegistrarNotas.TabIndex = 0;
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
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(745, 380);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 27);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tlRegistrarNotas
            // 
            this.tlRegistrarNotas.ColumnCount = 2;
            this.tlRegistrarNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlRegistrarNotas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlRegistrarNotas.Controls.Add(this.dgvRegistrarNotas, 0, 1);
            this.tlRegistrarNotas.Controls.Add(this.btnSalir, 1, 2);
            this.tlRegistrarNotas.Controls.Add(this.btnActualizar, 0, 2);
            this.tlRegistrarNotas.Controls.Add(this.comboBox1, 0, 0);
            this.tlRegistrarNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRegistrarNotas.Location = new System.Drawing.Point(0, 0);
            this.tlRegistrarNotas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlRegistrarNotas.Name = "tlRegistrarNotas";
            this.tlRegistrarNotas.RowCount = 3;
            this.tlRegistrarNotas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlRegistrarNotas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlRegistrarNotas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlRegistrarNotas.Size = new System.Drawing.Size(933, 410);
            this.tlRegistrarNotas.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(841, 380);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 27);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(736, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // RegistrarNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 435);
            this.Controls.Add(this.tscRegistrarNotas);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RegistrarNotas";
            this.Text = "RegistrarNotas";
            this.Load += new System.EventHandler(this.RegistrarNotas_Load);
            this.tscRegistrarNotas.ContentPanel.ResumeLayout(false);
            this.tscRegistrarNotas.TopToolStripPanel.ResumeLayout(false);
            this.tscRegistrarNotas.TopToolStripPanel.PerformLayout();
            this.tscRegistrarNotas.ResumeLayout(false);
            this.tscRegistrarNotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrarNotas)).EndInit();
            this.tsRegistrarNotas.ResumeLayout(false);
            this.tsRegistrarNotas.PerformLayout();
            this.tlRegistrarNotas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscRegistrarNotas;
        private System.Windows.Forms.DataGridView dgvRegistrarNotas;
        private System.Windows.Forms.ToolStrip tsRegistrarNotas;
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
        private System.Windows.Forms.TableLayoutPanel tlRegistrarNotas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

