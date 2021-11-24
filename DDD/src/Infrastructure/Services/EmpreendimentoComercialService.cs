using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;
using Domain.Entities;
using Application.Repository.Interfaces;
using Application.DTO;


namespace Infrastructure.Services
{
    public class EmpreendimentoComercialService : IEmpreendimentoComercialService
    {
        private readonly IEmpreendimentoRepository<EmpreendimentoComercial> _Repository;
        public EmpreendimentoComercialService(IEmpreendimentoRepository<EmpreendimentoComercial> repository)
        {
            _Repository = repository;
        }

        public async Task<string> AdicionarEmpreendimentoComercial(EmpreendimentoComercialDTO request)
        {
            var empreendimento = new EmpreendimentoComercial { Id = 0, Nome = request.Nome, Valor = request.Valor, Area = request.Area };
            empreendimento = await _Repository.Add(empreendimento);
            return "Empreendimento comercial adicionado com sucesso!";
        }

        public async Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosComerciais()
        {
            var Resultado = new BuscarEmpreendimentosResponse { Status = "200", Dados = await _Repository.Get() };
            return Resultado;
        }

        public async Task<string> AtualizarEmpreendimentoComercial(EmpreendimentoComercial request)
        {
            var empreendimento = new EmpreendimentoComercial { Id = request.Id, Nome = request.Nome, Valor = request.Valor, Area = request.Area };
            var Response = await _Repository.Edit(empreendimento);
            return Response;
        }

        public async Task<string> ExcluirEmpreendimentoComercial(int id)
        {
            var Result = await _Repository.Delete(id);
            return Result;
        }

    }
}
