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
    public interface IEmpreendimentoMoradiaService
    {
        public Task<string> AdicionarEmpreendimentoMoradia(EmpreendimentoMoradiaDTO request);
        public Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosMoradia();
        public Task<string> AtualizarEmpreendimentoMoradia(EmpreendimentoMoradia request);
        public Task<string> ExcluirEmpreendimentoMoradia(int id);
    }
}
