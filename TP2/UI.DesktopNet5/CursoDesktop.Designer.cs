
namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.lblAnoCalendario = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.lblComision = new System.Windows.Forms.Label();
            this.nudAnoCalendario = new System.Windows.Forms.NumericUpDown();
            this.nudCupo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoCalendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCupo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(13, 13);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 42);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 15);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(118, 39);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(235, 23);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(118, 10);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(235, 23);
            this.txtID.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(13, 192);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 36);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(208, 192);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(13, 129);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(47, 15);
            this.lblMateria.TabIndex = 13;
            this.lblMateria.Text = "Materia";
            // 
            // cbMateria
            // 
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(118, 126);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(235, 23);
            this.cbMateria.TabIndex = 14;
            this.cbMateria.ValueMember = "ID";
            // 
            // lblAnoCalendario
            // 
            this.lblAnoCalendario.AutoSize = true;
            this.lblAnoCalendario.Location = new System.Drawing.Point(13, 71);
            this.lblAnoCalendario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnoCalendario.Name = "lblAnoCalendario";
            this.lblAnoCalendario.Size = new System.Drawing.Size(89, 15);
            this.lblAnoCalendario.TabIndex = 15;
            this.lblAnoCalendario.Text = "Año Calendario";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(13, 100);
            this.lblCupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(36, 15);
            this.lblCupo.TabIndex = 18;
            this.lblCupo.Text = "Cupo";
            // 
            // cbComision
            // 
            this.cbComision.DisplayMember = "Descripcion";
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(118, 156);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(235, 23);
            this.cbComision.TabIndex = 20;
            this.cbComision.ValueMember = "ID";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(13, 159);
            this.lblComision.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(58, 15);
            this.lblComision.TabIndex = 19;
            this.lblComision.Text = "Comision";
            // 
            // nudAnoCalendario
            // 
            this.nudAnoCalendario.Location = new System.Drawing.Point(118, 69);
            this.nudAnoCalendario.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudAnoCalendario.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.nudAnoCalendario.Name = "nudAnoCalendario";
            this.nudAnoCalendario.Size = new System.Drawing.Size(235, 23);
            this.nudAnoCalendario.TabIndex = 21;
            this.nudAnoCalendario.Value = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            // 
            // nudCupo
            // 
            this.nudCupo.Location = new System.Drawing.Point(118, 98);
            this.nudCupo.Name = "nudCupo";
            this.nudCupo.Size = new System.Drawing.Size(235, 23);
            this.nudCupo.TabIndex = 22;
            this.nudCupo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 240);
            this.Controls.Add(this.nudCupo);
            this.Controls.Add(this.nudAnoCalendario);
            this.Controls.Add(this.cbComision);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.lblAnoCalendario);
            this.Controls.Add(this.cbMateria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CursoDesktop";
            this.Text = "Curso";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoCalendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.Label lblAnoCalendario;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.NumericUpDown nudAnoCalendario;
        private System.Windows.Forms.NumericUpDown nudCupo;
    }
}

