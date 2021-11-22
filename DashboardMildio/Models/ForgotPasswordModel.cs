using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Campo obrigat�rio!")]
        public string email { get; set; }

    }
}