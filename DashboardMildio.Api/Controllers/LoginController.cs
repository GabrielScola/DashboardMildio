using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashboardMildio.Application;
using DashboardMildio.Repository;
using DashboardMildio.Api.Models; 

namespace DashboardMildio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string strConexao;

        public LoginController(IConfiguration config)
        {
            strConexao = config.GetConnectionString("conexao");
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Usuario userModel)
        {
            try
            {
                UsuarioRepository userRepository = new UsuarioRepository(strConexao);
                UsuarioApplication userApplication = new UsuarioApplication(userRepository);

                var user = userApplication.Autenticar(userModel.User, userModel.Senha);

                var token = Services.TokenService.GenerateToken(user);

                user.Senha = "";
                userModel.Token = token;

                return Ok(userModel);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
