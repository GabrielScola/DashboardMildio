using DashboardMildio.Api.Models;
using DashboardMildio.Application;
using DashboardMildio.Application.DTO;
using DashboardMildio.Domain.Repository;
using DashboardMildio.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardMildio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : ControllerBase
    {
        private readonly IDadosRepository dataRepository;
        private readonly DadosApplication dataApplication;

        public DadosController(IConfiguration config)
        {
            string strConexao = config.GetConnectionString("conexao");
            dataRepository = new DadosRepository(strConexao);
            dataApplication = new DadosApplication(dataRepository);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allData = dataApplication.GetAll();

                List<Dados> listDados = new List<Dados>();

                foreach (var dadosDTO in allData)
                {
                    listDados.Add(new Dados()
                    {
                        Id = dadosDTO.Id,
                        Temperatura = dadosDTO.Temperatura,
                        Chuva = dadosDTO.Chuva,
                        Humidade = dadosDTO.Umidade,
                        Data = dadosDTO.Data
                    });
                }

                return Ok(listDados);
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dados dados)
        {
            try
            {
                DadosDTO dadosDTO = new DadosDTO()
                {
                    Id = Guid.NewGuid(),
                    Temperatura = dados.Temperatura,
                    Chuva = dados.Chuva,
                    Umidade = dados.Humidade,
                    Data = dados.Data
                };

                Guid id = dataApplication.Insert(dadosDTO);

                return Ok(id);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Dados dados)
        {
            try
            {
                DadosDTO dadosDTO = new DadosDTO()
                {
                    Id = dados.Id,
                    Temperatura = dados.Temperatura,
                    Chuva = dados.Chuva,
                    Umidade = dados.Humidade,
                    Data = dados.Data
                };

                dataApplication.Update(dadosDTO);

                return Ok(id);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                dataApplication.Delete(id);

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
