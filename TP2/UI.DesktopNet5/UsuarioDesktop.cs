﻿using System;
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
using FluentValidation;
using FluentValidation.Results;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly PersonaLogic _personaLogic;
        private Usuario UsuarioActual { set; get; }
        public UsuarioDesktop(AcademyContext context)
        {
            InitializeComponent();
            _usuarioLogic = new UsuarioLogic(new UsuarioAdapter(context));
            _personaLogic = new PersonaLogic(new PersonaAdapter(context));
        }
        public UsuarioDesktop(ModoForm modo, AcademyContext context) : this(context)
        {
            // Este constructor es cuando doy de alta un nuevo usuario
            Modos = modo;
            // Creo el nuevo usuario acá para después poder asignarle el ID de persona
            UsuarioActual = new Usuario();
            // Está todo deshabilitado hasta que cargues un legajo que coincida con una persona
            this.txtUsuario.ReadOnly = true;
            this.chkHabilitado.Enabled = false;
            this.txtClave.ReadOnly = true;
            this.txtConfirmarClave.ReadOnly = true;
        }
        public UsuarioDesktop(int ID, ModoForm modo, AcademyContext context) : this(context)
        {
            Modos = modo;
            try
            {
                UsuarioActual = _usuarioLogic.GetOne(ID);
                // Como estoy modificando o borrando el usuario, no tengo que poder modificar el legajo
                // al cual está asociado
                this.txtLegajo.Enabled = false;
                MapearDeDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            // La clave no la tengo que cargar porque no se muestra, siempre se vuelve a poner de 0
            // Ahora tengo que cargar los datos de la persona también
            try
            {
                Persona per = _personaLogic.GetOne(UsuarioActual.IDPersona);
                this.txtLegajo.Text = per.Legajo.ToString();
                this.txtNombre.Text = per.Nombre;
                this.txtApellido.Text = per.Apellido;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    this.txtUsuario.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            if (this.txtClave.Text != "")
            {
                UsuarioActual.Clave = this.txtClave.Text;
            }
            UsuarioActual.NombreUsuario = this.txtUsuario.Text;
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
            try
            {
                MapearADatos();
                if (this.txtConfirmarClave.Text == this.txtClave.Text)
                {
                    if (Validar())
                    {
                        _usuarioLogic.Save(UsuarioActual);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override bool Validar()
        {
            ValidationResult result = new UsuarioValidator().Validate(UsuarioActual);
            
            if (!result.IsValid)
            {
                string notificacion = string.Join(Environment.NewLine, result.Errors);
                MessageBox.Show(notificacion);
                return false;
            }
            return true;


        }
        // Esto se podría hacer un nivel más arriba y ya usarlo para la implementación en web
        // Habría que darle un par de vueltas de tuerca, capaz en validaciones se puede meter
        // Aparte seguro se puede hacer muchisimo más eficiente
        private void cargarPersona()
        {
            this.btnAceptar.Enabled = false;
            List<Persona> personas = _personaLogic.GetAll();
            try
            {
                // Esta validacion tiene q ser q no es vacio y q son solo numeros
                // Metele regex a este if pa
                if (this.txtLegajo.Text.Length == 0)
                {
                    Exception e = new Exception("Ingrese un legajo.");
                    throw e;
                }
                var persona = (from p in personas
                               where p.Legajo == Int32.Parse(this.txtLegajo.Text)
                               select p).ToList();
                if (persona.Count == 0)
                {
                    Exception e = new Exception("No existe persona para el legajo ingresado.");
                    throw e;
                }
                Persona per = _personaLogic.GetOne(persona[0].ID);
                // Asigno los datos de la persona a los textbox
                this.txtNombre.Text = per.Nombre;
                this.txtApellido.Text = per.Apellido;
                // Verifico que no exista un usuario ya para esta persona
                var usuarios = (from u in _usuarioLogic.GetAll()
                                where u.IDPersona == per.ID
                                select u);
                if (usuarios.Any())
                {
                    Exception e = new Exception("Ya existe un usuario para la persona ingresada.");
                    throw e;
                }
                UsuarioActual.IDPersona = per.ID;
                // Una vez que cargo la persona, vuelvo a habilitar el resto de los elementos
                this.btnAceptar.Enabled = true;
                this.txtUsuario.ReadOnly = false;
                this.chkHabilitado.Enabled = true;
                this.txtClave.ReadOnly = false;
                this.txtConfirmarClave.ReadOnly = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modos)
            {
                case ModoForm.Alta:
                    {
                        GuardarCambios();
                    };
                    break;
                case ModoForm.Modificacion:
                    {
                        GuardarCambios();
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
            try
            {
                _usuarioLogic.Delete(UsuarioActual.ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            cargarPersona();
        }
    }
}
