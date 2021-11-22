using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class DadosModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obrigat�rio")]
        public int Temperatura { get; set; }
        [Required(ErrorMessage = "Campo obrigat�rio")]
        public int Chuva { get; set; }
        [Required(ErrorMessage = "Campo obrigat�rio")]
        public int Humidade { get; set; }
        [Required(ErrorMessage = "Campo obrigat�rio")]
        public DateTime Date { get; set; }
    }
}