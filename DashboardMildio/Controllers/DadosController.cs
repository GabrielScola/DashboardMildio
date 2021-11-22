using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashboardMildio.Models;
using DashboardMildio.ClientHTTP;
using Newtonsoft.Json;

namespace DashboardMildio.Controllers
{
    public class DadosController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            List<DadosModel> dados = clienteHTTP.Get<List<DadosModel>>(@"dados");

            return View(dados);
        }

        [Route("/cadastrar")]
        public IActionResult Form()
        {
            ViewBag.Data = new DadosModel();

            return View();
        }

        [Route("/dados/cadastro/{id:int}")]
        public IActionResult Cadastro(int id)
        {
            return View("form");
        }

        [Route("/dados/cadastro/{id:alpha}")]
        public IActionResult Cadastro(string id)
        {
            return View("form");
        }

        [HttpPost]
        public IActionResult Cadastrar(DadosModel dados)
        {
            if (ModelState.IsValid)
            {
                APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
                Guid id = clienteHTTP.Post<DadosModel>(@"dados", dados);
                return RedirectToAction("Index");
            } else
            {
                ViewBag.Data = dados;
                return View("form");
            }
        }

        [HttpPost]
        public IActionResult Pesquisar(Guid id)
        {
            string listaDados = HttpContext.Session.GetString("listadados");
            List<DadosModel> dados = JsonConvert.DeserializeObject<List<DadosModel>>(listaDados);
            var dado = dados.Where(x => x.Id == id).ToList<DadosModel>();

            if (dado == null)
            {
                return Json(dados);
            }
            else
            {
                return Json(dado);
            }
        }

        [HttpPost]
        public IActionResult ExcluirDado(Guid idDado)
        {
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            clienteHTTP.Delete<DadosModel>("dado", idDado);
            var dados = clienteHTTP.Get<List<DadosModel>>(@"dado");
            return Json(dados);
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            List<DadosModel> dados = clienteHTTP.Get<List<DadosModel>>(@"dado");

            var dado = dados.Where(p => p.Id == id).FirstOrDefault();

            if(dado == null)
            {
                dado = new DadosModel();
            }
            return View(dado);
        }

        [HttpPost]
        public IActionResult Alterar(DadosModel dado)
        {
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            Guid id = clienteHTTP.Put<DadosModel>(@"dado", dado.Id, dado);
            return RedirectToAction("Index");
        }
    }
}