using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using UI.Web.Models;
using jsreport.AspNetCore;
using jsreport.Types;

namespace Unidad._5.Lab._1.MVC.Controllers
{
    public class ControllerMain: Controller
    {

        public ControllerMain() {}
        [Authorize]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult DescargarPDF()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = "attachment; filename=\"estadoAcademico.pdf\"");
            int idAlumno = Convert.ToInt32(
                    User.Claims.FirstOrDefault(
                        c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier
                        )?.Value
                    );
            return View("Index", new ListEstadoAcademicoViewModel(_alumnoInscripcionLogic.GetEstadoAcademico(idAlumno), _personaLogic.GetOne(idAlumno)));
        }
    }
}