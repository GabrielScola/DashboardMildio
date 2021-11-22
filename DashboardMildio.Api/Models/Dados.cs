using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardMildio.Api.Models
{
    public class Dados
    {
        public Guid Id { get; set; }
        public int Temperatura { get; set; }
        public int Chuva { get; set; }
        public int Humidade { get; set; }
        public DateTime Data { get; set; }
    }
}

