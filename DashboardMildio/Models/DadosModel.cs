using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class DadosModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Temperatura { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Chuva { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Humidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Date { get; set; }
    }
}