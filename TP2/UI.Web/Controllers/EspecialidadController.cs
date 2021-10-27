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
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_especialidadLogic.GetAll().OrderBy(e => e.Descripcion).ToList());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Especialidad? especialidad = _especialidadLogic.GetOne((int)id);
            if (especialidad == null) return NotFound();
            return View(especialidad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int id, [Bind("ID, Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.ID) return NotFound();
            try
            {
                if (!ModelState.IsValid) return View(especialidad);

                especialidad.State = BusinessEntity.States.Modified;
                _especialidadLogic.Save(especialidad);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al editar la especialidad.");
                return View(especialidad);
            }
                return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(null);
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Descripcion")] Especialidad especialidad)
        {
            try
            {
                if (!ModelState.IsValid) return View(especialidad);

                especialidad.State = BusinessEntity.States.New;
                _especialidadLogic.Save(especialidad);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al crear la especialidad");
                return View(especialidad);
            }
                return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Especialidad? especialidad = _especialidadLogic.GetOne((int)id);
            if (_especialidadLogic == null) return NotFound();
            return View(especialidad);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, Especialidad especialidad)
        {
            if (id != especialidad.ID) return NotFound();
            try
            {
                especialidad.State = BusinessEntity.States.Deleted;
                _especialidadLogic.Save(especialidad);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al eliminar la especialidad.");
                return View(_especialidadLogic.GetOne(id));
            }
            return RedirectToAction("List");
        }
    }
}
