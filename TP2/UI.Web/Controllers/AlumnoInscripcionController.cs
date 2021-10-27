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
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(new ListAlumnoInscripcionViewModel(_alumnoInscripcionLogic.GetAll(), _cursoLogic.GetAll()));
        /* ESTO NO VA PORQUE NO SE PUEDE EDITAR INSCRIPCION
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            AlumnoInscripcion? alumnoinscripcion = _alumnoInscripcionLogic.GetOne((int)id);
            if (alumnoinscripcion == null) return NotFound();
            return View(new EditAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
        }

        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, IDAlumno,IDCurso, Condicion, Curso, Nota, IDPersona, Persona")] AlumnoInscripcion alumnoinscripcion)
        {
            if (id != alumnoinscripcion.ID) return NotFound();
            try
            {
                if (!ModelState.IsValid) return View(new EditAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
                alumnoinscripcion.State = BusinessEntity.States.Modified;
                _alumnoInscripcionLogic.Save(alumnoinscripcion);
            } catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al editar la inscripción.");
                return View(new EditAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll(), _personaLogic.GetAll()));
            }
            return RedirectToAction("List");
        }*/
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreateAlumnoInscripcionViewModel(null, _cursoLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, IDAlumno, IDCurso, Condicion, Nota")] AlumnoInscripcion alumnoinscripcion)
        {
            try
            {
                if (!ModelState.IsValid) return View(new CreateAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll()));
                alumnoinscripcion.State = BusinessEntity.States.New;
                _alumnoInscripcionLogic.Save(alumnoinscripcion);
            } catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al crear la inscripción.");
                return View(new CreateAlumnoInscripcionViewModel(alumnoinscripcion, _cursoLogic.GetAll()));
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            AlumnoInscripcion? alumnoinscripcion = _alumnoInscripcionLogic.GetOne((int)id);
            if (alumnoinscripcion == null) return NotFound();
            return View(alumnoinscripcion);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, AlumnoInscripcion alumnoinscripcion)
        {
            if (id != alumnoinscripcion.ID) return NotFound();
            try
            {
                alumnoinscripcion.State = BusinessEntity.States.Deleted;
                _alumnoInscripcionLogic.Save(alumnoinscripcion);
            } catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al eliminar la inscripción.");
                return View(_alumnoInscripcionLogic.GetOne(id));
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult GetPersona(int legajo)
        {
            Persona persona = _personaLogic.GetOneConLegajo(legajo);
            if (persona == null || ((int)persona.TipoPersona) != 1)
            {
                return StatusCode(500);
            }
            else
            {
                return PartialView("Partial_AlumnoInscripcion", new CreateAlumnoInscripcionPartialViewModel(persona));
            }
        }
    }
}
