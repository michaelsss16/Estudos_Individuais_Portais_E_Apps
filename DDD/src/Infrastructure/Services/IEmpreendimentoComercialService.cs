using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;
using Domain.Entities;
using Application.DTO;

namespace Infrastructure.Services
{
    public interface IEmpreendimentoComercialService
    {
        public Task<string> AdicionarEmpreendimentoComercial(EmpreendimentoComercialDTO request);
        public Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosComerciais();
        public Task<EmpreendimentoComercial> BuscarEmpreendimentoComercialPorId(int id);
        public Task<string> AtualizarEmpreendimentoComercial(EmpreendimentoComercial request);
        public Task<string> ExcluirEmpreendimentoComercial(int id);
    }
}
