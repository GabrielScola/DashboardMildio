using DashboardMildio.Application.DTO;
using DashboardMildio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Application.Adapter
{
    public class UsuarioAdapter
    {
        public static UsuarioDTO ParaUsuarioDTO(Usuario user)
        {
            return new UsuarioDTO()
            {
                Id = user.Id,
                Email = user.Email,
                User = user.User
            };
        }

        public static Usuario ParaUsuarioDominio(UsuarioDTO usuarioDTO)
        {
            return new Usuario()
            {
                Id = usuarioDTO.Id,
                Email = usuarioDTO.Email,
                User = usuarioDTO.User
            };
        }
    }
}
