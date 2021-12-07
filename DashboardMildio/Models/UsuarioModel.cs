using System;

namespace DashboardMildio.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public String User { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public object Token{ get; set; }
    }
}
