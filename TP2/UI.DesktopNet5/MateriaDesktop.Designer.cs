
namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.lblPlan = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.lblHorasSemanales = new System.Windows.Forms.Label();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.nudHorasSemanales = new System.Windows.Forms.NumericUpDown();
            this.nudHorasTotales = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasTotales)).BeginInit();
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
            this.btnAceptar.Location = new System.Drawing.Point(13, 155);
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
            this.btnCancelar.Location = new System.Drawing.Point(208, 155);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(13, 129);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(30, 15);
            this.lblPlan.TabIndex = 13;
            this.lblPlan.Text = "Plan";
            // 
            // cbPlan
            // 
            this.cbPlan.DisplayMember = "Descripcion";
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(118, 126);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(235, 23);
            this.cbPlan.TabIndex = 14;
            this.cbPlan.ValueMember = "ID";
            // 
            // lblHorasSemanales
            // 
            this.lblHorasSemanales.AutoSize = true;
            this.lblHorasSemanales.Location = new System.Drawing.Point(13, 71);
            this.lblHorasSemanales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHorasSemanales.Name = "lblHorasSemanales";
            this.lblHorasSemanales.Size = new System.Drawing.Size(96, 15);
            this.lblHorasSemanales.TabIndex = 15;
            this.lblHorasSemanales.Text = "Horas semanales";
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(118, 68);
            this.txtHorasSemanales.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(235, 23);
            this.txtHorasSemanales.TabIndex = 16;
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.Location = new System.Drawing.Point(118, 97);
            this.txtHorasTotales.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(235, 23);
            this.txtHorasTotales.TabIndex = 17;
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.Location = new System.Drawing.Point(13, 100);
            this.lblHorasTotales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(76, 15);
            this.lblHorasTotales.TabIndex = 18;
            this.lblHorasTotales.Text = "Horas totales";
            // 
            // nudHorasSemanales
            // 
            this.nudHorasSemanales.Location = new System.Drawing.Point(98, 45);
            this.nudHorasSemanales.Name = "nudHorasSemanales";
            this.nudHorasSemanales.Size = new System.Drawing.Size(120, 23);
            this.nudHorasSemanales.TabIndex = 19;
            // 
            // nudHorasTotales
            // 
            this.nudHorasTotales.Location = new System.Drawing.Point(123, 86);
            this.nudHorasTotales.Name = "nudHorasTotales";
            this.nudHorasTotales.Size = new System.Drawing.Size(120, 23);
            this.nudHorasTotales.TabIndex = 20;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 195);
            this.Controls.Add(this.nudHorasTotales);
            this.Controls.Add(this.nudHorasSemanales);
            this.Controls.Add(this.lblHorasTotales);
            this.Controls.Add(this.txtHorasTotales);
            this.Controls.Add(this.txtHorasSemanales);
            this.Controls.Add(this.lblHorasSemanales);
            this.Controls.Add(this.cbPlan);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriaDesktop";
            this.Text = "Materia";
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasTotales)).EndInit();
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
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.Label lblHorasSemanales;
        private System.Windows.Forms.TextBox txtHorasSemanales;
        private System.Windows.Forms.TextBox txtHorasTotales;
        private System.Windows.Forms.Label lblHorasTotales;
        private System.Windows.Forms.NumericUpDown nudHorasSemanales;
        private System.Windows.Forms.NumericUpDown nudHorasTotales;
    }
}

