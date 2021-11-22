using DashboardMildio.Domain.Entidades;
using DashboardMildio.Domain.Repository;
using System;
using System.Collections.Generic;
using Npgsql;

namespace DashboardMildio.Repository
{
    public class DadosRepository : IDadosRepository
    {
        private string strConexao;

        public DadosRepository(string strConexao)
        {
            this.strConexao = strConexao;
        }
        
        public void Add(Dados dados)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(strConexao))
            {
                conn.Open();

                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = conn;

                comando.CommandText = "INSERT INTO dados (id, tempteratura, chuva, humidade, data) VALUES (@id, @tempteratura, @chuva, @humidade, @data);";

                comando.Parameters.AddWithValue("id", dados.Id);
                comando.Parameters.AddWithValue("tempteratura", dados.Temperatura);
                comando.Parameters.AddWithValue("chuva", dados.Chuva);
                comando.Parameters.AddWithValue("humidade", dados.Humidade);
                comando.Parameters.AddWithValue("data", dados.Data);

                comando.ExecuteNonQuery();
            }

            
        }

        public void Delete(Guid idDados)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(strConexao))
            {
                conn.Open();
                NpgsqlCommand comando = new();
                comando.Connection = conn;
                comando.CommandText = "DELETE FROM dados WHERE id=@id";
                comando.Parameters.AddWithValue("id", idDados);
                comando.ExecuteNonQuery();
            }
        }

        public Dados Get(Guid idDados)
        {
            Dados dados = null;
            using (NpgsqlConnection conn = new NpgsqlConnection(strConexao))
            {
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = conn;

                comando.CommandText = "SELECT * FROM dados WHERE id=@id";
                comando.Parameters.AddWithValue("id", idDados);

                NpgsqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    dados = new Dados()
                    {
                        Id = Guid.Parse(leitor["id"].ToString()),
                        Temperatura = Int32.Parse(leitor["temperatura"].ToString()),
                        Chuva = Int32.Parse(leitor["chuva"].ToString()),
                        Humidade = Int32.Parse(leitor["humidade"].ToString()),
                        Data = Convert.ToDateTime(leitor["data"].ToString())
                    };
                }
            }
            return dados;
        }

        public List<Dados> GetAll()
        {
            List<Dados> listaDados = new();

            using (NpgsqlConnection conn = new(strConexao))
            {
                conn.Open();

                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = conn;

                comando.CommandText = "SELECT * FROM dados;";

                NpgsqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    listaDados.Add(
                        new Dados()
                        {
                            Id = Guid.Parse(leitor["id"].ToString()),
                            Temperatura = Int32.Parse(leitor["temperatura"].ToString()),
                            Chuva = Int32.Parse(leitor["chuva"].ToString()),
                            Humidade = Int32.Parse(leitor["humidade"].ToString()),
                            Data = Convert.ToDateTime(leitor["data"].ToString())
                        }); ;
                }
            }
            return listaDados;
        }

        public void Update(Dados dados)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(strConexao))
            {

                conn.Open();

                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = conn;

                comando.CommandText = "UPDATE dados SET temperatura = @temperatura, chuva = @chuva, humidade = @humidade, data = @data WHERE id = @id;";

                comando.Parameters.AddWithValue("id", dados.Id);
                comando.Parameters.AddWithValue("temperature", dados.Temperatura);
                comando.Parameters.AddWithValue("rain", dados.Chuva);
                comando.Parameters.AddWithValue("humidity", dados.Humidade);
                comando.Parameters.AddWithValue("date", dados.Data);

                comando.ExecuteNonQuery();
            }
        }
    }
}
