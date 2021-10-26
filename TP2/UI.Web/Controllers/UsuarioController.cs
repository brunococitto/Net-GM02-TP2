using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Business.Logic;
using Business.Entities;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly UsuarioLogic _usuarioLogic;
        private readonly PersonaLogic _personaLogic;

        public UsuarioController(ILogger<UsuarioController> logger,UsuarioLogic usuarioLogic ,PersonaLogic personaLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador UsuarioController");
            _usuarioLogic = usuarioLogic;
            _personaLogic = personaLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        public IActionResult List() => View(_usuarioLogic.GetAll());
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Usuario? usuario = _usuarioLogic.GetOne((int)id);
            if (usuario == null) return NotFound();
            return View(parsearEdit(usuario));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, NombreUsuario, Habilitado, Clave, IDPersona")] UsuarioEdit edit)
        {
            if (id != edit.ID) return NotFound();
            if (ModelState.IsValid)
            {
                Usuario usr = parsearUsr(edit);
                usr.State = BusinessEntity.States.Modified;
                _usuarioLogic.Save(usr);
                return RedirectToAction("List");
            }
            return View((edit));
        }
        [HttpGet]
        public IActionResult Create() => View(null);
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, NombreUsuario, Habilitado, Clave, IDPersona")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.State = BusinessEntity.States.New;
                _usuarioLogic.Save(usuario);
                return RedirectToAction("List");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Usuario? usuario = _usuarioLogic.GetOne((int)id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Delete(int id, Usuario usuario)
        {
            if (id != usuario.ID) return NotFound();
            usuario.State = BusinessEntity.States.Deleted;
            _usuarioLogic.Save(usuario);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult GetPersona(int legajo)
        {
            Persona persona = _personaLogic.GetOneConLegajo(legajo);
            if (persona == null) 
            {
                return StatusCode(500);
            }
            else
            {
                return PartialView("Partial_Usuario",new CreateUsuarioPartialViewModel(persona));
            }
            
        }
        private UsuarioEdit parsearEdit(Usuario usr)
        {
            UsuarioEdit ue = new UsuarioEdit();
            ue.ID = usr.ID;
            ue.NombreUsuario = usr.NombreUsuario;
            ue.Habilitado = usr.Habilitado;
            ue.Clave = usr.Clave;
            ue.IDPersona = usr.IDPersona;
            ue.Persona = usr.Persona;
            ue.Salt = usr.Salt;
            return ue;
        }
        private Usuario parsearUsr(UsuarioEdit ue)
        {
            Usuario usr = new Usuario();
            usr.ID = ue.ID;
            usr.NombreUsuario = ue.NombreUsuario;
            usr.Habilitado = ue.Habilitado;
            usr.Clave = ue.Clave;
            usr.IDPersona = ue.IDPersona;
            usr.Persona = ue.Persona;
            usr.Salt = ue.Salt;
            return usr;
        }
    }
}
