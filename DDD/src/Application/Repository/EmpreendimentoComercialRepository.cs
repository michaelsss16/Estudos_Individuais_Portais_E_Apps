using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTO;
using Application.Repository.Interfaces;

namespace Application.Repository
{
    public class EmpreendimentoComercialRepository : IEmpreendimentoRepository<EmpreendimentoComercial>
    {
        int Quantidade = 0;
        private static Dictionary<int, EmpreendimentoComercial> comerciais = new Dictionary<int, EmpreendimentoComercial>();
        public EmpreendimentoComercialRepository() { }
        public async Task<IEnumerable<EmpreendimentoComercial>> Get()
        {
            return await Task.Run(() => comerciais.Values.ToList());
        }

        public async Task<EmpreendimentoComercial> GetById (int id)
        {
            return await Task.Run(() => comerciais.GetValueOrDefault(id));
        }


        public async Task<EmpreendimentoComercial> Add(EmpreendimentoComercial comercial)
        {
            comercial.Id = Quantidade;
            await Task.Run(() => comerciais.Add(comercial.Id, comercial));
            Quantidade++;
            return comercial;
        }

        //put
        public async Task<string> Edit(EmpreendimentoComercial comercial)
        {
            await Task.Run(() => comerciais.Remove(comercial.Id));
            await Task.Run(() => comerciais.Add(comercial.Id, comercial));
            return "Empreendimento comercial atualizado com sucesso!";
        }

        // DELETE
        public async Task<string> Delete(int id)
        {
            await Task.Run(() => comerciais.Remove(id));
            return "Empreendimento comercial excluído com sucesso!";
        }
    }
}
