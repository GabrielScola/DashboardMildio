using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Domain.Entidades
{
    public class Dados
    {
        public Guid Id { get; set; }
        public int Temperatura { get; set; }
        public int Chuva { get; set; }
        public int Humidade { get; set; }
        public DateTime Data { get; set; }

        public Dados()
        {
            Id = new Guid();
            Temperatura = 0;
            Chuva = 0;
            Humidade = 0;
            Data = new DateTime();
        }
    }
}
