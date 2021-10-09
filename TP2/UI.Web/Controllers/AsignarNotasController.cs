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
    public class AsignarNotasController : Controller
    {
        private readonly ILogger<AlumnoInscripcionController> _logger;
        private readonly AlumnoInscripcionLogic _alumnoInscripcionLogic;
        private readonly DocenteCursoLogic _docenteCursoLogic;
        public AsignarNotasController(ILogger<AlumnoInscripcionController> logger, DocenteCursoLogic docenteCursoLogic, AlumnoInscripcionLogic alumnoInscripcionLogic)
        {
            _logger = logger;
            _logger.LogDebug("Inicializado controlador AsignarNotasController");
            _alumnoInscripcionLogic = alumnoInscripcionLogic;
            _docenteCursoLogic = docenteCursoLogic;
        }
        [Authorize(Roles = "Profesor")]
        public IActionResult Index()
        {
            int idProfesor = Convert.ToInt32(
                    User.Claims.FirstOrDefault(
                        c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier
                        )?.Value
                    );
            return View(_docenteCursoLogic.GetCursosProfesor(idProfesor));
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult ListaAlumnos(int? id)
        {
            if (id == null) return NotFound();
            List<AlumnoInscripcion> listaAlumnos = _alumnoInscripcionLogic.GetInscripcionesCurso((int)id);
            if (listaAlumnos == null) return NotFound();
            return View(listaAlumnos);
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult CargarNota(int? id)
        {
            if (id == null) return NotFound();
            AlumnoInscripcion? inscripcion = _alumnoInscripcionLogic.GetOne((int)id);
            if (inscripcion == null) return NotFound();
            return View(inscripcion);
        }
        [HttpPost]
        [Authorize(Roles = "Profesor")]
        [ValidateAntiForgeryToken]
        public IActionResult CargarNota(int id, [Bind("ID, IDAlumno, IDCurso, Condicion, Nota")] AlumnoInscripcion inscripcion)
        {
            if (id != inscripcion.ID) return NotFound();
            if (ModelState.IsValid)
            {
                inscripcion.State = BusinessEntity.States.Modified;
                _alumnoInscripcionLogic.Save(inscripcion);
                return RedirectToAction("ListaAlumnos", "AsignarNotas", new { id = inscripcion.IDCurso });
            }
            return View(inscripcion);
        }
    }
}
