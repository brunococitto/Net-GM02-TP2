using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Web.Models;
using UI.Web.Providers;
using Business.Logic;
using Business.Entities;

namespace Unidad._5.Lab._1.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly IUsuarioManager _usuarioManager;

        public AccountController(UsuarioLogic usuarioLogic, IUsuarioManager usuarioManager)
        {
            _usuarioLogic = usuarioLogic;
            _usuarioManager = usuarioManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            var loggedUser = UsuarioLogeado.MapearUsuario(_usuarioLogic.Login(loginVM.NombreUsuario, loginVM.Clave)); 

            if (loggedUser == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(loginVM);
            }

            await _usuarioManager.SignIn(this.HttpContext, loggedUser, loginVM.IsPersistent);

            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _usuarioManager.SignOut(this.HttpContext);

            return RedirectToActionPermanent(controllerName: "Home", actionName: "Index");
        }
    }
}