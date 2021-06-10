using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modos = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modos = modo;
            UsuarioLogic u = new UsuarioLogic();
            UsuarioActual = u.GetOne(ID);
            MapearDeDatos();
        }


        public Usuario UsuarioActual { set; get; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

            switch (this.Modos)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }


        }


        public override void MapearADatos()
        {
            if (Modos == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            }

            if (Modos == ModoForm.Modificacion)
            {
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            }

            switch (Modos)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
            }


        }

        public override void GuardarCambios()
        {
            UsuarioLogic u = new UsuarioLogic();
            MapearADatos();
            u.Save(UsuarioActual);

        }
        public override bool Validar()
        {

            if (string.IsNullOrWhiteSpace(this.txtApellido.Text) || string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtUsuario.Text))
            {
                Notificar("Error", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                Notificar("Error", "La clave debe tener 8 o más caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Error", "La clave no coincide con la confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!this.txtEmail.Text.Contains("@") || !this.txtEmail.Text.Contains("."))
            {
                Notificar("Error", "El Email no es valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else { return true; }

        }




        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (Modos)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Baja:
                    Eliminar();
                    Close();
                    break;
                case ModoForm.Consulta:
                    Close();
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public virtual void Eliminar()
        {
            UsuarioLogic u = new UsuarioLogic();
            u.Delete(UsuarioActual.ID);

        }

    }
}
