using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly PersonaLogic _personaLogic;
        public formLogin(AcademyContext context)
        {
            InitializeComponent();
            _usuarioLogic = new UsuarioLogic(new UsuarioAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usr = _usuarioLogic.Login(this.txtUsuario.Text, this.txtPass.Text);
                if (usr != null)
                {
                    if (usr.Habilitado == true)
                    {
                        Singleton.setInstance(_personaLogic.GetOne(usr.IDPersona), usr);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Usuario no habilitado, contactese con su administrador", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario incorrecto", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Solicite al administrador que cambie su clave", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
