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
        public IActionResult List() => View(_docenteCursoLogic.GetAll());
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            DocenteCurso? docenteCurso = _docenteCursoLogic.GetOne((int)id);
            if (docenteCurso == null) return NotFound();
            return View(new EditDocenteCursoViewModel(docenteCurso, _personaLogic.GetAll(),_cursoLogic.GetAll()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Cargo, Curso, IDCurso, IDDocente,Persona")] DocenteCurso docenteCurso)
        {
            Console.WriteLine($"asd");
            if (id != docenteCurso.ID) return NotFound();
            if (ModelState.IsValid)
            {
                docenteCurso.State = BusinessEntity.States.Modified;
                _docenteCursoLogic.Save(docenteCurso);
                return RedirectToAction("List");
            }
            return View(new EditDocenteCursoViewModel(docenteCurso, _personaLogic.GetAll(), _cursoLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Create() => View(new CreateDocenteCursoViewModel(null, _personaLogic.GetAll(), _cursoLogic.GetAll()));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Cargo, Curso, IDCurso, IDDocente,Persona")] DocenteCurso docenteCurso)
        {
            if (ModelState.IsValid)
            {
                
                docenteCurso.State = BusinessEntity.States.New;
                _docenteCursoLogic.Save(docenteCurso);
                return RedirectToAction("List");
            }
            return View(new CreateDocenteCursoViewModel(docenteCurso, _personaLogic.GetAll(), _cursoLogic.GetAll()));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            DocenteCurso? docenteCurso = _docenteCursoLogic.GetOne((int)id);
            if (docenteCurso == null) return NotFound();
            return View(docenteCurso);
        }
        [HttpPost]
        public IActionResult Delete(int id, DocenteCurso docenteCurso)
        {
            if (id != docenteCurso.ID) return NotFound();
            docenteCurso.State = BusinessEntity.States.Deleted;
            _docenteCursoLogic.Save(docenteCurso);
            return RedirectToAction("List");
        }
    }
}
