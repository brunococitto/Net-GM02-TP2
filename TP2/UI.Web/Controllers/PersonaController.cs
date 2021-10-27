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
using Microsoft.AspNetCore.Authorization;

namespace UI.Web.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly PersonaLogic _personaLogic;
        private readonly PlanLogic _planLogic;
        public PersonaController(ILogger<PersonaController> logger, PersonaLogic personaLogic, PlanLogic planLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador ComisionController");
            _personaLogic = personaLogic;
            _planLogic = planLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_personaLogic.GetAll().OrderBy(p => p.Legajo).ToList());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Persona? persona = _personaLogic.GetOne((int)id);
            if (persona == null) return NotFound();
            return View(new EditPersonaViewModel(persona, _planLogic.GetAll()));
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Legajo, Nombre, Apellido, Direccion, Email, Telefono, FechaNacimiento, IDPlan, TipoPersona")] Persona persona)
        {
            Console.WriteLine($"asd");
            if (id != persona.ID) return NotFound();
            try
            {
                if (!ModelState.IsValid) return View(new EditPersonaViewModel(persona, _planLogic.GetAll()));
                if (persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    persona.IDPlan = null;
                }
                persona.State = BusinessEntity.States.Modified;
                _personaLogic.Save(persona);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al editar la persona.");
                return View(new EditPersonaViewModel(persona, _planLogic.GetAll()));
            }
                return RedirectToAction("List");
            
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreatePersonaViewModel(null, _planLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Legajo, Nombre, Apellido, Direccion, Email, Telefono, FechaNacimiento, IDPlan, TipoPersona")] Persona persona)
        {
            try
            {
                if (!ModelState.IsValid) return View(new CreatePersonaViewModel(persona, _planLogic.GetAll()));
                if (persona.TipoPersona == Persona.TiposPersona.Administrativo)
                {
                    persona.IDPlan = null;
                }
                persona.State = BusinessEntity.States.New;
                _personaLogic.Save(persona);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al crear la persona");
                return View(new CreatePersonaViewModel(persona, _planLogic.GetAll()));
            }
                return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Persona? persona = _personaLogic.GetOne((int)id);
            if (persona == null) return NotFound();
            return View(persona);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, Persona persona)
        {
            if (id != persona.ID) return NotFound();
            try
            {
                persona.State = BusinessEntity.States.Deleted;
                _personaLogic.Save(persona);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al eliminar la persona.");
                return View(_personaLogic.GetOne(id));
            }
            return RedirectToAction("List");
        }
    }
}
