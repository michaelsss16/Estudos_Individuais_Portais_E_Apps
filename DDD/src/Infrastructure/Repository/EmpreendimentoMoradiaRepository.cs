using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Responses;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Application.DTO;

namespace Infrastructure.Repository
{
    public class EmpreendimentoMoradiaRepository : IEmpreendimentoMoradiaRepository
    {
        int Quantidade = 0;
        private static Dictionary<int, EmpreendimentoMoradia> moradias = new Dictionary<int, EmpreendimentoMoradia>();
        public EmpreendimentoMoradiaRepository() { }

        public async Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosMoradia()
        {
            var Resultado = new BuscarEmpreendimentosResponse { Status = "200", Dados = await Task.Run(() => moradias.Values.ToList()) };
            return Resultado;
        }

        public async Task<EmpreendimentoMoradia> BuscarEmpreendimentoMoradiaPorId(int id)
        {
            var Resultado = await Task.Run(() => moradias.GetValueOrDefault(id));
            return Resultado;
        }

        public async Task<string> AdicionarEmpreendimentoMoradia(EmpreendimentoMoradiaDTO request)
        {
            var moradia = new EmpreendimentoMoradia { Id = Quantidade, Nome = request.Nome, Valor = request.Valor, QuantidadeDeQuartos = request.QuantidadeDeQuartos };
            await Task.Run(() => moradias.Add(moradia.Id, moradia));
            Quantidade++;
            return "Empreendimento de moradia adicionado com sucesso!";
        }

        public async Task<string> AtualizarEmpreendimentoMoradia(EmpreendimentoMoradia request)
        {
            var moradia = new EmpreendimentoMoradia { Id = request.Id, Nome = request.Nome, Valor = request.Valor, QuantidadeDeQuartos = request.QuantidadeDeQuartos };
            await Task.Run(() => moradias.Remove(moradia.Id));
            await Task.Run(() => moradias.Add(moradia.Id, moradia));
            return "Empreendimento de moradia atualizado com sucesso!";
        }

        public async Task<string> ExcluirEmpreendimentoMoradia(int id)
        {
            await Task.Run(() => moradias.Remove(id));
            return "Empreendimento de moradia excluído com sucesso!";
        }

    }
}
