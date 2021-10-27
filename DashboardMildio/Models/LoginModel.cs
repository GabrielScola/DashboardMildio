using System;
using System.ComponentModel.DataAnnotations;

namespace DashboardMildio.Models
{
    public class LoginModel
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string senha { get; set; }

    }
}