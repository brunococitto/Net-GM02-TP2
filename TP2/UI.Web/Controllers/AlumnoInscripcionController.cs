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
    public class AlumnoInscripcionController : Controller
    {
        private readonly ILogger<AlumnoInscripcionController> _logger;
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly CursoLogic _cursoLogic;
        private readonly PersonaLogic _personaLogic;
        public AlumnoInscripcionController(ILogger<AlumnoInscripcionController> logger, CursoLogic cursoLogic, AlumnoInscripcionLogic alumnoInscripcionLogic, PersonaLogic personaLogic)
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador AlumnoInscripcionController");
            _alumnoInscripcionLogic = alumnoInscripcionLogic;
            _cursoLogic = cursoLogic;
            _personaLogic = personaLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        public IActionResult List() => View(_alumnoInscripcionLogic.GetAll());

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            AlumnoInscripcion? alumnoinscripcion = _alumnoInscripcionLogic.GetOne((int)id);
            if (alumnoinscripcion == null) return NotFound();
            return View(new EditAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Condicion, Curso, Nota, IDCurso, IDPersona, Persona")] AlumnoInscripcion alumnoinscripcion)
        {
            if (id != alumnoinscripcion.ID) return NotFound();
            if (ModelState.IsValid)
            {
                alumnoinscripcion.State = BusinessEntity.States.Modified;
                _alumnoInscripcionLogic.Save(alumnoinscripcion);
                return RedirectToAction("List");
            }
            return View(new EditAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Create() => View(new CreateAlumnoInscripcionViewModel(null, _cursoLogic.GetAll(), _personaLogic.GetAll()));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, IDAlumno, Condicion, Curso, Nota, IDCurso, IDPersona, Persona")] AlumnoInscripcion alumnoinscripcion)
        {
            if (ModelState.IsValid)
            {
                alumnoinscripcion.State = BusinessEntity.States.New;
                _alumnoInscripcionLogic.Save(alumnoinscripcion);
                return RedirectToAction("List");
            }
            return View(new CreateAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            AlumnoInscripcion? alumnoinscripcion = _alumnoInscripcionLogic.GetOne((int)id);
            if (alumnoinscripcion == null) return NotFound();
            return View(alumnoinscripcion);
        }
        [HttpPost]
        public IActionResult Delete(int id, AlumnoInscripcion alumnoinscripcion)
        {
            if (id != alumnoinscripcion.ID) return NotFound();
            alumnoinscripcion.State = BusinessEntity.States.Deleted;
            _alumnoInscripcionLogic.Save(alumnoinscripcion);
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
                return PartialView("Partial_AlumnoInscripcion", persona);
            }

        }
    }
}
