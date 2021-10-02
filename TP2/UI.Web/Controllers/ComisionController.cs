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
    public class ComisionController : Controller
    {
        private readonly ILogger<ComisionController> _logger;
        private readonly ComisionLogic _comisionLogic;
        private readonly PlanLogic _planLogic;
        public ComisionController(ILogger<ComisionController> logger, ComisionLogic comisionLogic, PlanLogic planLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador ComisionController");
            _comisionLogic = comisionLogic;
            _planLogic = planLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_comisionLogic.GetAll());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Comision? comision = _comisionLogic.GetOne((int)id);
            if (comision == null) return NotFound();
            return View(new EditComisionViewModel(comision, _planLogic.GetAll()));
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Descripcion, AnoEspecialidad, IDPlan")] Comision comision)
        {
            if (id != comision.ID) return NotFound();
            if (ModelState.IsValid)
            {
                comision.State = BusinessEntity.States.Modified;
                _comisionLogic.Save(comision);
                return RedirectToAction("List");
            }
            return View(new EditComisionViewModel(comision, _planLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreateComisionViewModel(null, _planLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Descripcion, AnoEspecialidad, IDPlan")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                comision.State = BusinessEntity.States.New;
                _comisionLogic.Save(comision);
                return RedirectToAction("List");
            }
            return View(new CreateComisionViewModel(comision, _planLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Comision? comision = _comisionLogic.GetOne((int)id);
            if (comision == null) return NotFound();
            return View(comision);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, Comision comision)
        {
            if (id != comision.ID) return NotFound();
            comision.State = BusinessEntity.States.Deleted;
            _comisionLogic.Save(comision);
            return RedirectToAction("List");
        }
    }
}
