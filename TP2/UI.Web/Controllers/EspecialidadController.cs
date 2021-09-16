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
    public class EspecialidadController : Controller
    {
        private readonly ILogger<MateriaController> _logger;
        private readonly EspecialidadLogic _especialidadLogic;
        public EspecialidadController(ILogger<MateriaController> logger, EspecialidadLogic especialidadLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador EspecialidadController");
            _especialidadLogic = especialidadLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        public IActionResult List() => View(_especialidadLogic.GetAll());

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Especialidad? especialidad = _especialidadLogic.GetOne((int)id);
            if (especialidad == null) return NotFound();
            return View(especialidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.ID) return NotFound();
            if (ModelState.IsValid)
            {
                especialidad.State = BusinessEntity.States.Modified;
                _especialidadLogic.Save(especialidad);
                return RedirectToAction("List");
            }
            return View(especialidad);
        }
        [HttpGet]
        public IActionResult Create() => View(null);
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Descripcion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                especialidad.State = BusinessEntity.States.New;
                _especialidadLogic.Save(especialidad);
                return RedirectToAction("List");
            }
            return View(especialidad);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Especialidad? especialidad = _especialidadLogic.GetOne((int)id);
            if (_especialidadLogic == null) return NotFound();
            return View(especialidad);
        }
        [HttpPost]
        public IActionResult Delete(int id, Especialidad especialidad)
        {
            if (id != especialidad.ID) return NotFound();
            especialidad.State = BusinessEntity.States.Deleted;
            _especialidadLogic.Save(especialidad);
            return RedirectToAction("List");
        }
    }
}
