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
    public interface IClienteRepository
    {
        public Task<string> AdicionarCliente(ClienteDTO request);
        public Task<BuscarClientesResponse> BuscarTodosOsClientes();
        public Task<Cliente> BuscarClientePorId(int id);
        public Task<string> AtualizarCliente(Cliente request);
        public Task<string> ExcluirCliente(int id);
    }
}
