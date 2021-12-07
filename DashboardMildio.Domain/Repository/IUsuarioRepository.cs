using DashboardMildio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Domain.Repository
{
    public interface IUsuarioRepository
    {
        public List<Usuario> FindAll();
        public Usuario Autenticar(string usuario);
        public Usuario Insert(Usuario usuario);
        public Usuario Update(Usuario usuario);
        public Usuario Delete(Guid idUsuario);
    }
}
