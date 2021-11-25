using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;
using Domain.Entities;
using Application.DTO;

namespace Infrastructure.Repository.Interfaces
{
    public interface IEmpreendimentoMoradiaRepository
    {
        public Task<string> AdicionarEmpreendimentoMoradia(EmpreendimentoMoradiaDTO request);
        public Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosMoradia();
        public Task<EmpreendimentoMoradia> BuscarEmpreendimentoMoradiaPorId(int id);
        public Task<string> AtualizarEmpreendimentoMoradia(EmpreendimentoMoradia request);
        public Task<string> ExcluirEmpreendimentoMoradia(int id);
    }
}
