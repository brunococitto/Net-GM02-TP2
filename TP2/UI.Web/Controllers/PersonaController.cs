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
    public class PersonaController : Controller
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly PersonaLogic _peronaLogic;
        private readonly PlanLogic _planLogic;
        public PersonaController(ILogger<PersonaController> logger, PersonaLogic personaLogic, PlanLogic planLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador ComisionController");
            _peronaLogic = personaLogic;
            _planLogic = planLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        public IActionResult List() => View(_peronaLogic.GetAll());
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Persona? persona = _peronaLogic.GetOne((int)id);
            if (persona == null) return NotFound();
            return View(new EditPersonaViewModel(persona, _planLogic.GetAll()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Legajo, Nombre, Apellido, Direccion, Email, Telefono, FechaNacimiento, IDPlan, TipoPersona")] Persona persona)
        {
            if (id != persona.ID) return NotFound();
            if (ModelState.IsValid)
            {
                persona.State = BusinessEntity.States.Modified;
                _peronaLogic.Save(persona);
                return RedirectToAction("List");
            }
            return View(new EditPersonaViewModel(persona, _planLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Create() => View(new CreatePersonaViewModel(null, _planLogic.GetAll()));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Legajo, Nombre, Apellido, Direccion, Email, Telefono, FechaNacimiento, IDPlan, TipoPersona")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.State = BusinessEntity.States.New;
                _peronaLogic.Save(persona);
                return RedirectToAction("List");
            }
            return View(new CreatePersonaViewModel(persona, _planLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Persona? persona = _peronaLogic.GetOne((int)id);
            if (persona == null) return NotFound();
            return View(persona);
        }
        [HttpPost]
        public IActionResult Delete(int id, Persona persona)
        {
            if (id != persona.ID) return NotFound();
            persona.State = BusinessEntity.States.Deleted;
            _peronaLogic.Save(persona);
            return RedirectToAction("List");
        }
    }
}
