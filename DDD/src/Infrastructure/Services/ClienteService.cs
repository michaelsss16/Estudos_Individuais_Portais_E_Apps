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
    public class ClienteService
    {
        private readonly IClienteRepository _repository;
        ClienteService(IClienteRepository repository) { 
            _repository = repository;
        }

        public async Task<string> AdicionarCliente(ClienteDTO request) {
            var cliente = new Cliente {Id = 0, Nome = request.Nome, CPF= request.CPF, Identificador = Guid.NewGuid() };
            cliente = await _repository.Add(cliente);
            return "Pessoa criada com sucesso!";
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosOsClientes() {
            var Resultado = await _repository.Get();
            return Resultado;
        }

    }
}
