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
using jsreport.AspNetCore;
using jsreport.Types;

namespace UI.Web.Controllers
{
    public class PlanController : Controller
    {
        private readonly ILogger<PlanController> _logger;
        private readonly EspecialidadLogic _especialidadLogic;
        private readonly PlanLogic _planLogic;
        public PlanController(ILogger<PlanController> logger, EspecialidadLogic especialidadLogic, PlanLogic planLogic) 
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador PlanController");
            _especialidadLogic = especialidadLogic;
            _planLogic = planLogic;
        }
        public IActionResult Index() => RedirectToAction("List");
        [Authorize(Roles = "Administrativo")]
        public IActionResult List() => View(_planLogic.GetAll().OrderBy(p => p.Descripcion).ToList());
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Plan? plan = _planLogic.GetOne((int)id);
            if (plan == null) return NotFound();
            return View(new EditPlanViewModel(plan, _especialidadLogic.GetAll()));
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, Descripcion, IDEspecialidad")] Plan plan)
        {
            if (id != plan.ID) return NotFound();
            if (ModelState.IsValid)
            {
                plan.State = BusinessEntity.States.Modified;
                _planLogic.Save(plan);
                return RedirectToAction("List");
            }
            return View(new EditPlanViewModel(plan, _especialidadLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create() => View(new CreatePlanViewModel(null, _especialidadLogic.GetAll()));
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Descripcion, IDEspecialidad")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                plan.State = BusinessEntity.States.New;
                _planLogic.Save(plan);
                return RedirectToAction("List");
            }
            return View(new CreatePlanViewModel(plan, _especialidadLogic.GetAll()));
        }
        [HttpGet]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Plan? plan = _planLogic.GetOne((int)id);
            if (plan == null) return NotFound();
            return View(plan);
        }
        [HttpPost]
        [Authorize(Roles = "Administrativo")]
        public IActionResult Delete(int id, Plan plan)
        {
            if (id != plan.ID) return NotFound();
            plan.State = BusinessEntity.States.Deleted;
            _planLogic.Save(plan);
            return RedirectToAction("List");
        }
        [MiddlewareFilter(typeof(JsReportPipeline))]
        [Authorize(Roles = "Administrativo")]
        public IActionResult DescargarPDF()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = $"attachment; filename=\"planes-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf\"");
            int idAlumno = Convert.ToInt32(
                    User.Claims.FirstOrDefault(
                        c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier
                        )?.Value
                    );
            return View("Reporte", _planLogic.GetAll().OrderBy(p => p.Descripcion).ToList());
        }
    }
}
