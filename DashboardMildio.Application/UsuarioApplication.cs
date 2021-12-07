using DashboardMildio.Application.Adapter;
using DashboardMildio.Application.DTO;
using DashboardMildio.Domain.Entidades;
using DashboardMildio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Application
{
    public class UsuarioApplication
    {
        private IUsuarioRepository userRepository;

        public UsuarioApplication(IUsuarioRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UsuarioDTO Find(string user)
        {
            var usuario = userRepository.Autenticar(user);

            return UsuarioAdapter.ParaUsuarioDTO(usuario);
        }

        public Guid Insert(UsuarioDTO usuarioDTO)
        {
            if(string.IsNullOrEmpty(usuarioDTO.User))
            {
                throw new ApplicationException();
            }

            Usuario user = UsuarioAdapter.ParaUsuarioDominio(usuarioDTO);
            userRepository.Insert(user);
            return user.Id;
        }

        public Guid Update(UsuarioDTO usuarioDTO)
        {
            if (string.IsNullOrEmpty(usuarioDTO.User))
            {
                throw new ApplicationException();
            }

            Usuario user = UsuarioAdapter.ParaUsuarioDominio(usuarioDTO);
            userRepository.Update(user);
            return user.Id;
        }

        public void Delete(Guid idUsuario)
        {
            userRepository.Delete(idUsuario);
        }

        public Usuario Autenticar(string usuario, string senha)
        {
            var user = this.userRepository.Autenticar(usuario);
            if(user.User != null)
            {
                if(user.Senha == senha)
                {
                    return user;
                }
            }
            throw new ApplicationException("Usuário e/ou senha incorretos.");
        }

    }
}
