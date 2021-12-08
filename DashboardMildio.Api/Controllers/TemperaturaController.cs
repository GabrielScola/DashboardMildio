using DashboardMildio.Api.Models;
using DashboardMildio.Application;
using DashboardMildio.Domain.Repository;
using DashboardMildio.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DashboardMildio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturaController : ControllerBase
    {
        private IDadosRepository dadosRepository;
        private DadosApplication dadosApplication;

        public TemperaturaController(IConfiguration config)
        {
            string conexao = config.GetConnectionString("conexao");
            dadosRepository = new DadosRepository(conexao);
            dadosApplication = new DadosApplication(dadosRepository);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dados = dadosApplication.GetAll();
            List<DadosTemperatura> dadosModel = new List<DadosTemperatura>();

            foreach (var dadosDTO in dados)
            {
                dadosModel.Add(new DadosTemperatura()
                {
                    Temperatura = dadosDTO.Temperatura,
                    Data = dadosDTO.Data,
                });
            }

            return Ok(dadosModel);
        }
    }
}
