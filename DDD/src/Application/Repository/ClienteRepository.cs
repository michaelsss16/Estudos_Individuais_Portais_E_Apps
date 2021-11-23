﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repository.Interfaces;
using Domain.Entities;

namespace Application.Repository
{
    public class ClienteRepository
    {
        int Quantidade = 0;
        private static Dictionary<int, Cliente> clientes= new Dictionary<int, Cliente>();

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



    }
}
