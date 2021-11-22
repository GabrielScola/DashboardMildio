using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class RecoverPasswordModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string confirmarSenha { get; set; }

    }
}