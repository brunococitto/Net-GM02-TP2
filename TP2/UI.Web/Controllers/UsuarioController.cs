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
            _logger.LogDebug("Inicializado controlador ComisionController");
            _usuarioLogic = usuarioLogic;
            _personaLogic = personaLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        public IActionResult List() => View(_personaLogic.GetAll());
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Usuario? usuario = _usuarioLogic.GetOne((int)id);
            if (usuario == null) return NotFound();
            return View(new EditUsuarioViewModel(usuario));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Legajo, Usuario, Habilitado, Clave")] Usuario usuario)
        {
            if (id != usuario.ID) return NotFound();
            if (ModelState.IsValid)
            {
                usuario.State = BusinessEntity.States.Modified;
                _usuarioLogic.Save(usuario);
                return RedirectToAction("List");
            }
            return View(new EditUsuarioViewModel(usuario));
        }
        [HttpGet]
        public IActionResult Create() => View(new CreateUsuarioViewModel(null, _personaLogic.GetAll()));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Legajo, Usuario, Habilitado, Clave")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.State = BusinessEntity.States.New;
                _usuarioLogic.Save(usuario);
                return RedirectToAction("List");
            }
            return View(new CreateUsuarioViewModel(usuario, _personaLogic.GetAll()));
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
    }
}
