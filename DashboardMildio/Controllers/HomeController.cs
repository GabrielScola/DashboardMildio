using DashboardMildio.ClientHTTP;
using DashboardMildio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardMildio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult JsonTemperatura()
        {
            List<List<string>> result = new();
            List<DadosTemperaturaModel> dadosTemperaturaLista = new();
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            try
            {
                dadosTemperaturaLista = clienteHTTP.Get<List<DadosTemperaturaModel>>(@"Temperatura");
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Temperatura", Type.GetType("System.String"));
                dataTable.Columns.Add("Data", Type.GetType("System.DateTime"));

                foreach (var item in dadosTemperaturaLista)
                {
                    DateTime hoje = DateTime.Now;
                    string dia = hoje.ToShortDateString();
                    DateTime inicio = DateTime.Parse($"{dia} 12:00:00");
                    DateTime fim = DateTime.Parse($"{dia} 23:59:00");
                    DataRow dr = dataTable.NewRow();


                    if (inicio <= item.Data && fim >= item.Data)
                    {
                        dr["Temperatura"] = item.Temperatura / 32;
                        dr["Data"] = item.Data;
                        dataTable.Rows.Add(dr);
                    }
                }

                List<string> dataList = new();
                List<string> temperaturaList = new();

                foreach(DataRow row in dataTable.Rows)
                {
                    dataList.Add(row["Data"].ToString());
                    temperaturaList.Add(row["Temperatura"].ToString());
                }
                result.Add(dataList);
                result.Add(temperaturaList);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro inesperado.");
            }
            return Json(result);
        }
        public JsonResult JsonChuva()
        {
            List<List<string>> result = new();
            List<DadosChuvaModel> dadosChuvaLista = new();
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            try
            {
                dadosChuvaLista = clienteHTTP.Get<List<DadosChuvaModel>>(@"Chuva");
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Chuva", Type.GetType("System.String"));
                dataTable.Columns.Add("Data", Type.GetType("System.DateTime"));

                foreach (var item in dadosChuvaLista)
                {
                    DateTime hoje = DateTime.Now;
                    string dia = hoje.ToShortDateString();
                    DateTime inicio = DateTime.Parse($"{dia} 12:00:00");
                    DateTime fim = DateTime.Parse($"{dia} 23:59:00");
                    DataRow dr = dataTable.NewRow();
                    dr["Chuva"] = item.Chuva;
                    dr["Data"] = item.Data;

                    if (inicio <= item.Data && fim >= item.Data)
                    {
                        dataTable.Rows.Add(dr);
                    }
                }

                List<string> dataList = new();
                List<string> chuvaList = new();

                foreach (DataRow row in dataTable.Rows)
                {
                    dataList.Add(row["Data"].ToString());
                    chuvaList.Add(row["Chuva"].ToString());
                }
                result.Add(dataList);
                result.Add(chuvaList);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro inesperado.");
            }
            return Json(result);
        }
        public JsonResult JsonUmidade()
        {
            List<List<string>> result = new();
            List<DadosUmidadeModel> dadosUmidadeLista = new();
            APIHttpClient clienteHTTP = new APIHttpClient("http://localhost:45945/api/");
            try
            {
                dadosUmidadeLista = clienteHTTP.Get<List<DadosUmidadeModel>>(@"Umidade");
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Umidade", Type.GetType("System.String"));
                dataTable.Columns.Add("Data", Type.GetType("System.DateTime"));

                foreach (var item in dadosUmidadeLista)
                {
                    DateTime hoje = DateTime.Now;
                    string dia = hoje.ToShortDateString();
                    DateTime inicio = DateTime.Parse($"{dia} 12:00:00");
                    DateTime fim = DateTime.Parse($"{dia} 23:59:00");
                    DataRow dr = dataTable.NewRow();
                    dr["Umidade"] = item.Umidade;
                    dr["Data"] = item.Data;

                    if (inicio <= item.Data && fim >= item.Data)
                    {
                        dataTable.Rows.Add(dr);
                    }
                }

                List<string> dataList = new();
                List<string> umidadeList = new();

                foreach (DataRow row in dataTable.Rows)
                {
                    dataList.Add(row["Data"].ToString());
                    umidadeList.Add(row["Umidade"].ToString());
                }
                result.Add(dataList);
                result.Add(umidadeList);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro inesperado.");
            }
            return Json(result);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Updates()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
