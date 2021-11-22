using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;

namespace Infrastructure.Services
{
    public interface IClienteService
    {
        public Task<AdicionarClienteResponse> AdicionarCliente(string nome, long cpf );
        public Task<BuscarClientesResponse> BuscarTodosOsClientes();
    }
}
