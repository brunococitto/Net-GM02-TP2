
namespace UI.Desktop
{
    partial class EstadoAcademico
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
            this.tscEstadoAcademico = new System.Windows.Forms.ToolStripContainer();
            this.tlEstadoAcademico = new System.Windows.Forms.TableLayoutPanel();
            this.dgvEstadoAcademico = new System.Windows.Forms.DataGridView();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tscEstadoAcademico.ContentPanel.SuspendLayout();
            this.tscEstadoAcademico.SuspendLayout();
            this.tlEstadoAcademico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoAcademico)).BeginInit();
            this.SuspendLayout();
            // 
            // tscEstadoAcademico
            // 
            // 
            // tscEstadoAcademico.ContentPanel
            // 
            this.tscEstadoAcademico.ContentPanel.Controls.Add(this.tlEstadoAcademico);
            this.tscEstadoAcademico.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscEstadoAcademico.ContentPanel.Size = new System.Drawing.Size(933, 410);
            this.tscEstadoAcademico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscEstadoAcademico.Location = new System.Drawing.Point(0, 0);
            this.tscEstadoAcademico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tscEstadoAcademico.Name = "tscEstadoAcademico";
            this.tscEstadoAcademico.Size = new System.Drawing.Size(933, 435);
            this.tscEstadoAcademico.TabIndex = 0;
            this.tscEstadoAcademico.Text = "toolStripContainer1";
            // 
            // tlEstadoAcademico
            // 
            this.tlEstadoAcademico.ColumnCount = 2;
            this.tlEstadoAcademico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEstadoAcademico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlEstadoAcademico.Controls.Add(this.dgvEstadoAcademico, 0, 0);
            this.tlEstadoAcademico.Controls.Add(this.btnActualizar, 1, 1);
            this.tlEstadoAcademico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEstadoAcademico.Location = new System.Drawing.Point(0, 0);
            this.tlEstadoAcademico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlEstadoAcademico.Name = "tlEstadoAcademico";
            this.tlEstadoAcademico.RowCount = 2;
            this.tlEstadoAcademico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEstadoAcademico.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlEstadoAcademico.Size = new System.Drawing.Size(933, 410);
            this.tlEstadoAcademico.TabIndex = 0;
            // 
            // dgvEstadoAcademico
            // 
            this.dgvEstadoAcademico.AllowUserToAddRows = false;
            this.dgvEstadoAcademico.AllowUserToDeleteRows = false;
            this.dgvEstadoAcademico.AllowUserToResizeColumns = false;
            this.dgvEstadoAcademico.AllowUserToResizeRows = false;
            this.dgvEstadoAcademico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadoAcademico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia,
            this.condicion,
            this.nota});
            this.tlEstadoAcademico.SetColumnSpan(this.dgvEstadoAcademico, 2);
            this.dgvEstadoAcademico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstadoAcademico.Location = new System.Drawing.Point(4, 3);
            this.dgvEstadoAcademico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvEstadoAcademico.MultiSelect = false;
            this.dgvEstadoAcademico.Name = "dgvEstadoAcademico";
            this.dgvEstadoAcademico.Size = new System.Drawing.Size(925, 371);
            this.dgvEstadoAcademico.TabIndex = 0;
            // 
            // materia
            // 
            this.materia.DataPropertyName = "Materia";
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
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
            // EstadoAcademico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 435);
            this.Controls.Add(this.tscEstadoAcademico);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EstadoAcademico";
            this.Text = "EstadoAcademico";
            this.Load += new System.EventHandler(this.EstadoAcademico_Load);
            this.tscEstadoAcademico.ContentPanel.ResumeLayout(false);
            this.tscEstadoAcademico.ResumeLayout(false);
            this.tscEstadoAcademico.PerformLayout();
            this.tlEstadoAcademico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoAcademico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscEstadoAcademico;
        private System.Windows.Forms.TableLayoutPanel tlEstadoAcademico;
        private System.Windows.Forms.DataGridView dgvEstadoAcademico;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
    }
}

