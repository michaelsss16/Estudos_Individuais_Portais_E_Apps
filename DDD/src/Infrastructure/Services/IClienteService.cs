﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Responses;
using Domain.Entities;
using Application.DTO;

namespace Infrastructure.Services
{
    public interface IClienteService
    {
        public Task<string> AdicionarCliente(ClienteDTO request);
        public Task<BuscarClientesResponse> BuscarTodosOsClientes();
        public Task<string> AtualizarCliente(Cliente request);
        public Task<string> ExcluirCliente(int id);
    }
}
