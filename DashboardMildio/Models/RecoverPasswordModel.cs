using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class RecoverPasswordModel
    {
        [Required]
        public string senha { get; set; }

        [Required]
        public string confirmarSenha { get; set; }

    }
}