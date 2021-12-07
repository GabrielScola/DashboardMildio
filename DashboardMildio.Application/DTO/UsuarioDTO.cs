using System;

namespace DashboardMildio.Application.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public String User { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
    }
}
