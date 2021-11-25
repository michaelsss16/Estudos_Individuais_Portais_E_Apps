using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;
using Infrastructure.Repository.Interfaces;
using Domain.Entities;
using Application.DTO;


namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        int Quantidade = 0;
        private static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
        public ClienteRepository() { }

        public async Task<BuscarClientesResponse> BuscarTodosOsClientes()
        {
            var Resultado = new BuscarClientesResponse { Status = "200", Dados = await Task.Run(() => clientes.Values.ToList()) };
            return Resultado;
        }

        public async Task<Cliente> BuscarClientePorId(int id)
        {
            var Resultado = await Task.Run(() => clientes.GetValueOrDefault(id));
            return Resultado;
        }

        public async Task<string> AdicionarCliente(ClienteDTO request)
        {
            var cliente = new Cliente { Id = Quantidade, Nome = request.Nome, CPF = request.CPF, Identificador = Guid.NewGuid() };
            await Task.Run(() => clientes.Add(cliente.Id, cliente));
            Quantidade++;
            return "Pessoa criada com sucesso!";
        }

        public async Task<string> AtualizarCliente(Cliente request)
        {
            var cliente = new Cliente { Id = request.Id, Nome = request.Nome, CPF = request.CPF, Identificador = Guid.NewGuid() };
            await Task.Run(() => clientes.Remove(cliente.Id));
            await Task.Run(() => clientes.Add(cliente.Id, cliente));
            return "Cliente atualizado com sucesso!";
        }

        public async Task<string> ExcluirCliente(int id)
        {
            await Task.Run(() => clientes.Remove(id));
            return "Cliente excluído com sucesso!";
        
    }

}
}
