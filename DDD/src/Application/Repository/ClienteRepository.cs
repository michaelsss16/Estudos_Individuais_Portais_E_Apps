using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repository.Interfaces;
using Domain.Entities;

namespace Application.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        int Quantidade = 0;
        private static Dictionary<int, Cliente> clientes= new Dictionary<int, Cliente>();
        public ClienteRepository() { }
                public async Task<IEnumerable<Cliente>>Get()
        {
            return await Task.Run(() => clientes.Values.ToList());
        }
                public async Task<Cliente> Add(Cliente cliente)
        {   
            cliente.Id = Quantidade;
            await Task.Run(() => clientes.Add(cliente.Id, cliente));
            Quantidade++;
            return cliente;
        }

        //put
        public async Task<string> Edit(Cliente cliente) { 
            await Task.Run(()=> clientes.Remove(cliente.Id));
            await Task.Run(()=> clientes.Add(cliente.Id, cliente));
            return "Cliente atualizado com sucesso!";
        }
        // DELETE
        public async Task<string> Delete(int id) {
            await Task.Run(()=> clientes.Remove(id));
            return "Cliente excluído com sucesso!";
        }



    }
}
