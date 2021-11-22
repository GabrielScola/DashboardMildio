using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string senha { get; set; }

    }
}