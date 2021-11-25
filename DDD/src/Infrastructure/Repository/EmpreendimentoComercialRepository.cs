using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTO;
using Infrastructure.Responses;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{
    public class EmpreendimentoComercialRepository : IEmpreendimentoComercialRepository
    {
        int Quantidade = 0;
        private static Dictionary<int, EmpreendimentoComercial> comerciais = new Dictionary<int, EmpreendimentoComercial>();
        public EmpreendimentoComercialRepository() { }


        public async Task<BuscarEmpreendimentosResponse> BuscarTodosOsEmpreendimentosComerciais()
        {
            var Resultado = new BuscarEmpreendimentosResponse { Status = "200", Dados = await Task.Run(() => comerciais.Values.ToList()) };
            return Resultado;
        }

        public async Task<EmpreendimentoComercial> BuscarEmpreendimentoComercialPorId(int id)
        {
            var Resultado = await Task.Run(() => comerciais.GetValueOrDefault(id));
            return Resultado;
        }
        public async Task<string> AdicionarEmpreendimentoComercial(EmpreendimentoComercialDTO request)
        {
            var comercial = new EmpreendimentoComercial { Id = Quantidade, Nome = request.Nome, Valor = request.Valor, Area = request.Area };
            await Task.Run(() => comerciais.Add(comercial.Id, comercial));
            Quantidade++;
            return "Empreendimento comercial adicionado com sucesso!";
        }

        public async Task<string> AtualizarEmpreendimentoComercial(EmpreendimentoComercial request)
        {
            var comercial = new EmpreendimentoComercial { Id = request.Id, Nome = request.Nome, Valor = request.Valor, Area = request.Area };
            await Task.Run(() => comerciais.Remove(comercial.Id));
            await Task.Run(() => comerciais.Add(comercial.Id, comercial));
            return "Empreendimento comercial atualizado com sucesso!";
        }

        public async Task<string> ExcluirEmpreendimentoComercial(int id)
        {
            await Task.Run(() => comerciais.Remove(id));
            return "Empreendimento comercial excluído com sucesso!";


        }

    }
}
