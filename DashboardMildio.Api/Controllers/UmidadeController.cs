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
    public class UmidadeController : ControllerBase
    {
        private IDadosRepository dadosRepository;
        private DadosApplication dadosApplication;

        public UmidadeController(IConfiguration config)
        {
            string conexao = config.GetConnectionString("conexao");
            dadosRepository = new DadosRepository(conexao);
            dadosApplication = new DadosApplication(dadosRepository);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dados = dadosApplication.GetAll();
            List<DadosUmidade> dadosModel = new List<DadosUmidade>();

            foreach (var dadosDTO in dados)
            {
                dadosModel.Add(new DadosUmidade()
                {
                    Umidade = dadosDTO.Umidade,
                    Data = dadosDTO.Data,
                });
            }

            return Ok(dadosModel);
        }
    }
}
