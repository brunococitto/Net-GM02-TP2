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
using Data.Database;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        private readonly UsuarioLogic _usuarioLogic;
        public formLogin(AcademyContext context)
        {
            InitializeComponent();
            _usuarioLogic = new UsuarioLogic(new UsuarioAdapter(context));
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usr = _usuarioLogic.Login(this.txtUsuario.Text, this.txtPass.Text);
            if (usr != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
