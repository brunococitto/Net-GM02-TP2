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
    public class DocenteCursoController : Controller
    {
        private readonly ILogger<DocenteCursoController> _logger;
        private readonly DocenteCursoLogic _docenteCursoLogic;
        private readonly PersonaLogic _personaLogic;
        private readonly CursoLogic _cursoLogic;
        public DocenteCursoController(ILogger<DocenteCursoController> logger,DocenteCursoLogic docenteCursoLogic, PersonaLogic personaLogic, CursoLogic cursoLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador ComisionController");
            _docenteCursoLogic = docenteCursoLogic;
            _personaLogic = personaLogic;
            _cursoLogic = cursoLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_docenteCursoLogic.GetAll());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            DocenteCurso? docenteCurso = _docenteCursoLogic.GetOne((int)id);
            if (docenteCurso == null) return NotFound();
            return View(new EditDocenteCursoViewModel(docenteCurso, _cursoLogic.GetAll()));
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Cargo, IDCurso, IDDocente")] DocenteCurso docenteCurso)
        {
            Console.WriteLine($"asd");
            if (id != docenteCurso.ID) return NotFound();
            if (ModelState.IsValid)
            {
                docenteCurso.State = BusinessEntity.States.Modified;
                _docenteCursoLogic.Save(docenteCurso);
                return RedirectToAction("List");
            }
            return View(new EditDocenteCursoViewModel(docenteCurso, _cursoLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreateDocenteCursoViewModel(null, _cursoLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Cargo, IDCurso, IDDocente")] DocenteCurso docenteCurso)
        {
            if (ModelState.IsValid)
            {
                
                docenteCurso.State = BusinessEntity.States.New;
                _docenteCursoLogic.Save(docenteCurso);
                return RedirectToAction("List");
            }
            return View(new CreateDocenteCursoViewModel(docenteCurso, _cursoLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            DocenteCurso? docenteCurso = _docenteCursoLogic.GetOne((int)id);
            if (docenteCurso == null) return NotFound();
            return View(docenteCurso);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, DocenteCurso docenteCurso)
        {
            if (id != docenteCurso.ID) return NotFound();
            docenteCurso.State = BusinessEntity.States.Deleted;
            _docenteCursoLogic.Save(docenteCurso);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult GetPersona(int legajo)
        {
            Persona persona = _personaLogic.GetOneConLegajo(legajo);
            if (persona == null | ((int)persona.TipoPersona) != 2)
            {
                return StatusCode(500);
            }
            else
            {
                return PartialView("Partial_DocenteCurso", new CreateDocenteCursoPartialViewModel(persona));
            }

        }
    }
}
