﻿using Microsoft.AspNetCore.Http;
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
    public class MateriaController : Controller
    {
        private readonly ILogger<MateriaController> _logger;
        private readonly MateriaLogic _materiaLogic;
        private readonly PlanLogic _planLogic;
        public MateriaController(ILogger<MateriaController> logger, MateriaLogic materiaLogic, PlanLogic planLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador MateriaController");
            _materiaLogic = materiaLogic;
            _planLogic = planLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_materiaLogic.GetAll().OrderBy(m => m.Descripcion).ToList());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Materia? materia = _materiaLogic.GetOne((int)id);
            if (materia == null) return NotFound();
            return View(new EditMateriaViewModel(materia, _planLogic.GetAll()));
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Descripcion, HSSemanales, HSTotales, IDPlan")] Materia materia)
        {
            if (id != materia.ID) return NotFound();
            try
            {
                if (!ModelState.IsValid) return View(new EditMateriaViewModel(materia, _planLogic.GetAll()));
                materia.State = BusinessEntity.States.Modified;
                _materiaLogic.Save(materia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al editar la materia.");
                return View(new EditMateriaViewModel(materia, _planLogic.GetAll()));
            }
                return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreateMateriaViewModel(null, _planLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Descripcion, HSSemanales, HSTotales, IDPlan")] Materia materia)
        {
            try
            {
                if (!ModelState.IsValid) return View(new CreateMateriaViewModel(materia, _planLogic.GetAll()));
                materia.State = BusinessEntity.States.New;
                _materiaLogic.Save(materia);
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al crear la materia.");
                return View(new CreateMateriaViewModel(materia, _planLogic.GetAll()));
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Materia? materia = _materiaLogic.GetOne((int)id);
            if (materia == null) return NotFound();
            return View(materia);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, Materia materia)
        {
            if (id != materia.ID) return NotFound();
            try
            {
                materia.State = BusinessEntity.States.Deleted;
                _materiaLogic.Save(materia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", "Se produjo un error al eliminar la materia.");
                return View(_materiaLogic.GetOne(id));
            }
            return RedirectToAction("List");
            
        }
    }
}
