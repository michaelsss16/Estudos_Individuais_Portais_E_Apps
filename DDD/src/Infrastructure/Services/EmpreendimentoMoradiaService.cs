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
    public class EmpreendimentoMoradiaService : IEmpreendimentoMoradiaService
    {
        private readonly IEmpreendimentoRepository<EmpreendimentoMoradia> _Repository;
        public EmpreendimentoMoradiaService(IEmpreendimentoRepository<EmpreendimentoMoradia> repository)
        {
            _Repository = repository;
        }

        public async Task<string> AdicionarEmpreendimentoMoradia(EmpreendimentoMoradiaDTO request)
        {
            var empreendimento = new EmpreendimentoMoradia { Id = 0, Nome = request.Nome, Valor = request.Valor, QuantidadeDeQuartos = request.QuantidadeDeQuartos };
            empreendimento = await _Repository.Add(empreendimento);
            return "Empreendimento comercial adicionado com sucesso!";
        }

        public async Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosMoradia()
        {
            var Resultado = new BuscarEmpreendimentosResponse { Status = "200", Dados = await _Repository.Get() };
            return Resultado;
        }

        public async Task<EmpreendimentoMoradia> BuscarEmpreendimentoMoradiaPorId(int id)
        {
            var Resultado = await _Repository.GetById(id);
            return Resultado;
        }


        public async Task<string> AtualizarEmpreendimentoMoradia(EmpreendimentoMoradia request)
        {
            var empreendimento = new EmpreendimentoMoradia { Id = request.Id, Nome = request.Nome, Valor = request.Valor, QuantidadeDeQuartos = request.QuantidadeDeQuartos };
            var Response = await _Repository.Edit(empreendimento);
            return Response;
        }

        public async Task<string> ExcluirEmpreendimentoMoradia(int id)
        {
            var Result = await _Repository.Delete(id);
            return Result;
        }

    }
}
