using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Repository.Interfaces
{
    public interface IEmpreendimentoRepository<T>
    {
        Task<T> Add(T empreendimento);
        Task<IEnumerable<T>> Get();
        Task<string> Delete(int id);
        Task<string> Edit(T empreendimento);
    }
}
