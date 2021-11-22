using DashboardMildio.Application.Adapter;
using DashboardMildio.Application.DTO;
using DashboardMildio.Domain.Entidades;
using DashboardMildio.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardMildio.Application
{
    public class DadosApplication
    {
        private IDadosRepository dadosRepository;

        public DadosApplication(IDadosRepository dadosRepository)
        {
            this.dadosRepository = dadosRepository;
        }
        
        public DadosDTO Get(Guid id)
        {
            var dados = dadosRepository.Get(id);
            return DadosAdapter.ParaDadosDTO(dados);
        }
        public Guid Insert(DadosDTO dadosDto)
        {
            Dados dados = DadosAdapter.ParaDadosDominio(dadosDto);
            dados.Id = Guid.NewGuid();
            dadosRepository.Add(dados);
            return dados.Id;
        }
        public Guid Update(DadosDTO dadosDto)
        {
            Dados dados = DadosAdapter.ParaDadosDominio(dadosDto);
            dadosRepository.Update(dados);
            return dados.Id;
        }
        public void Delete(Guid id)
        {
            dadosRepository.Delete(id);
        }
        public List<DadosDTO> GetAll()
        {
            List<Dados> dados = dadosRepository.GetAll();
            List<DadosDTO> dadosDTO = new List<DadosDTO>();

            foreach(var get in dados)
            {
                dadosDTO.Add(DadosAdapter.ParaDadosDTO(get));
            }

            return dadosDTO;
        }
    }
}
