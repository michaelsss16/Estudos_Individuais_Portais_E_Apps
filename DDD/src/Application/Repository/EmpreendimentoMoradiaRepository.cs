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
    public class EmpreendimentoMoradiaRepository : IEmpreendimentoRepository<EmpreendimentoMoradia>
    {
        int Quantidade = 0;
        private static Dictionary<int, EmpreendimentoMoradia> moradias = new Dictionary<int, EmpreendimentoMoradia>();
        public EmpreendimentoMoradiaRepository() { }
        public async Task<IEnumerable<EmpreendimentoMoradia>> Get()
        {
            return await Task.Run(() => moradias.Values.ToList());
        }
        public async Task<EmpreendimentoMoradia> Add(EmpreendimentoMoradia moradia)
        {
            moradia.Id = Quantidade;
            await Task.Run(() => moradias.Add(moradia.Id, moradia));
            Quantidade++;
            return moradia;
        }

        //put
        public async Task<string> Edit(EmpreendimentoMoradia moradia)
        {
            await Task.Run(() => moradias.Remove(moradia.Id));
            await Task.Run(() => moradias.Add(moradia.Id, moradia));
            return "Empreendimento de moradia atualizado com sucesso!";
        }
        // DELETE
        public async Task<string> Delete(int id)
        {
            await Task.Run(() => moradias.Remove(id));
            return "Empreendimento de moradia excluído com sucesso!";
        }
    }
}
