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
    public class EstadoAcademicoController : Controller
    {
        private readonly ILogger<AlumnoInscripcionController> _logger;
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly PersonaLogic _personaLogic;
        public EstadoAcademicoController(ILogger<AlumnoInscripcionController> logger, AlumnoInscripcionLogic alumnoInscripcionLogic, PersonaLogic personaLogic)
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador EstadoAcademicoController");
            _alumnoInscripcionLogic = alumnoInscripcionLogic;
            _personaLogic = personaLogic;
        }
        [Authorize(Roles = "Alumno")]
        public IActionResult Index()
        {
            int idAlumno = Convert.ToInt32(
                    User.Claims.FirstOrDefault(
                        c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier
                        )?.Value
                    );
            return View(new ListEstadoAcademicoViewModel(_alumnoInscripcionLogic.GetEstadoAcademico(idAlumno), _personaLogic.GetOne(idAlumno)));
        }
        [MiddlewareFilter(typeof(JsReportPipeline))]
        [Authorize(Roles = "Alumno")]
        public IActionResult DescargarPDF()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = $"attachment; filename=\"estadoAcademico-{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf\"");
            int idAlumno = Convert.ToInt32(
                    User.Claims.FirstOrDefault(
                        c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier
                        )?.Value
                    );
            return View("Reporte", new ListEstadoAcademicoViewModel(_alumnoInscripcionLogic.GetEstadoAcademico(idAlumno), _personaLogic.GetOne(idAlumno)));
        }
    }
}
