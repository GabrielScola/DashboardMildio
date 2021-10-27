using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        public string email { get; set; }

    }
}