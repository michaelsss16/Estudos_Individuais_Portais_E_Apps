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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _Repository;
        public ClienteService(IClienteRepository repository)
        {
            _Repository = repository;
        }

        public async Task<string> AdicionarCliente(ClienteDTO request)
        {
            var cliente = new Cliente { Id = 0, Nome = request.Nome, CPF = request.CPF, Identificador = Guid.NewGuid() };
            cliente = await _Repository.Add(cliente);
            return "Pessoa criada com sucesso!";
        }

        public async Task<BuscarClientesResponse> BuscarTodosOsClientes()
        {
            var Resultado = new BuscarClientesResponse { Status = "200", Dados = await _Repository.Get() };
            return Resultado;
        }

        //Atualizar cliente 
        public async Task<string> AtualizarCliente( Cliente request) {
            var cliente = new Cliente {Id=request.Id,Nome=request.Nome,  CPF= request.CPF, Identificador= Guid.NewGuid()};
            var Response = await _Repository.Edit( cliente);
            return Response;
        }

        //Excluir cliente 
        public async Task<string> ExcluirCliente(int id) {
            var Result = await _Repository.Delete(id);
            return Result;
        }

    }
}
