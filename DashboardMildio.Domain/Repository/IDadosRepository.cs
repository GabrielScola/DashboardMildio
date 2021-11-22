using DashboardMildio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Domain.Repository
{
    public interface IDadosRepository
    {
        public List<Dados> GetAll();
        public Dados Get(Guid idDados);
        public void Add(Dados dados);
        public void Update(Dados dados);
        public void Delete(Guid idDados);
    }
}
