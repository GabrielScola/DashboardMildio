using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Application.DTO
{
    public class DadosDTO
    {
        public Guid Id { get; set; }
        public int Temperatura { get; set; }
        public int Chuva { get; set; }
        public int Umidade { get; set; }
        public DateTime Data { get; set; }
    }
}
