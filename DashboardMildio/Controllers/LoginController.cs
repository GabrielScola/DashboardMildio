using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashboardMildio.Models;
using DashboardMildio.ClientHTTP;
using System;

namespace DashboardMildio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autenticar(string user, string senha)
        {
            UsuarioModel userModel = new UsuarioModel()
            {
                User = user,
                Senha = senha
            };

            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            try
            {
                userModel = clienteHTTP.Post<UsuarioModel>(@"Login", userModel);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ForgotPasswordRedirect(ForgotPasswordModel fg)
        {
            if (fg.email != null &&
                fg.email == "usu@usu.com")
            {
                return RedirectToAction("RecoverPassword");
            }

            return RedirectToAction("Index");
        }

        public ActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult RecoverPasswordRedirect(RecoverPasswordModel ps)
        {
            if(ps.senha != null &&
                ps.confirmarSenha != null &&
                ps.senha == ps.confirmarSenha)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("RecoverPassword");
        }
    }
}