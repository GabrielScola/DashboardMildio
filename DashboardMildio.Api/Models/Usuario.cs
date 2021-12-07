using System;

namespace DashboardMildio.Api.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String User { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public object Token { get; set; }
    }
}
