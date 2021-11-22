using DashboardMildio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardMildio.MockFactory
{
    public class MockFactory
    {
        public static List<DadosModel> GeraListaDados()
        {
            List<DadosModel> dados = new();

            dados.Add(new DadosModel()
            {
                Id = Guid.NewGuid(),
                Temperatura = 18,
                Chuva = 2,
                Humidade = 98,
                Date = new DateTime()
            });

            dados.Add(new DadosModel()
            {
                Id = Guid.NewGuid(),
                Temperatura = 25,
                Chuva = 5,
                Humidade = 75,
                Date = new DateTime()
            });

            dados.Add(new DadosModel()
            {
                Id = Guid.NewGuid(),
                Temperatura = 23,
                Chuva = 0,
                Humidade = 33,
                Date = new DateTime()
            });

            return dados;
        }
    }
}