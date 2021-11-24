using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTO;

namespace Application.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Add(Cliente cliente);
        Task<IEnumerable<Cliente>> Get();
        Task<string> Delete(int id);
        Task<string> Edit(Cliente cliente);

    }
}
