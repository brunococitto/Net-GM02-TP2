using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error/401")]
        public IActionResult NotAuthorized() => View();

        [Route("/error/404")]
        public IActionResult NotFoundError() => View();

        [Route("/error/{code:int}")]
        public IActionResult GenericError(int code)
        {
            _logger.LogInformation($"Error codigo {code}");
            _logger.LogError($"Mensaje exception: {HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error}");
            return View();
        }
    }
}