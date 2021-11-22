using DashboardMildio.Application.DTO;
using DashboardMildio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Application.Adapter
{
    public class DadosAdapter
    {
        public static DadosDTO ParaDadosDTO(Dados dados)
        {
            return new DadosDTO()
            {
                Id = dados.Id,
                Chuva = dados.Chuva,
                Temperatura = dados.Temperatura,
                Humidade = dados.Humidade,
                Data = dados.Data
            };
        }

        public static Dados ParaDadosDominio(DadosDTO dados)
        {
            return new Dados()
            {
                Id = dados.Id,
                Chuva = dados.Chuva,
                Temperatura = dados.Temperatura,
                Humidade = dados.Humidade,
                Data = dados.Data
            };
        }
    }
}
