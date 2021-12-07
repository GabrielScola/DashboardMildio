using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardMildio.Domain.Entidades;
using DashboardMildio.Domain.Repository;
using Npgsql;

namespace DashboardMildio.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string strConexao;

        public UsuarioRepository(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public Usuario Insert(Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Delete(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticar(string usuario)
        {
            Usuario user = null;
            using (NpgsqlConnection conn = new NpgsqlConnection(strConexao))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT usuario, senha FROM public.usuarios WHERE usuario=@usuario";
                cmd.Parameters.AddWithValue("usuario", usuario);
                NpgsqlDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    user = new Usuario()
                    {
                        User = leitor["usuario"].ToString(),
                        Senha = leitor["senha"].ToString()
                    };
                }

                return user;
            }
        }
    }
}
