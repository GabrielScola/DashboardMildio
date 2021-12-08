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
    public class ChuvaController : ControllerBase
    {
        private IDadosRepository dadosRepository;
        private DadosApplication dadosApplication;
        
        public ChuvaController(IConfiguration config)
        {
            string conexao = config.GetConnectionString("conexao");
            dadosRepository = new DadosRepository(conexao);
            dadosApplication = new DadosApplication(dadosRepository);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dados = dadosApplication.GetAll();
            List<Dados> dadosModel = new List<Dados>();

            foreach(var dadosDTO in dados)
            {
                dadosModel.Add(new Dados()
                {
                    Chuva = dadosDTO.Chuva,
                    Data = dadosDTO.Data
                });
            }

            return Ok(dadosModel);
        }
    }
}
