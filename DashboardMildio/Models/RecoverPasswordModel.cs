using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class RecoverPasswordModel
    {
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string confirmarSenha { get; set; }

    }
}