using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashboardMildio.Models;

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

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (login.usuario != null && 
                login.usuario == "usu" &&
                login.senha != null &&
                login.senha == "senha")
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("LoginError");
        }
        public ActionResult LoginError()
        {
            return View();
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