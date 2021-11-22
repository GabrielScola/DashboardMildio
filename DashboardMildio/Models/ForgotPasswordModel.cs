using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string email { get; set; }

    }
}