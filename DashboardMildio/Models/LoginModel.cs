using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string senha { get; set; }

    }
}