using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Application.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _Servico;
        public ClientesController(IClienteService servico) { 
            _Servico= servico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Servico.BuscarTodosOsClientes());
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO cliente)
        {
            var response = await _Servico.AdicionarCliente(cliente);
            return Ok(response);
        }

        //Put
        [HttpPut]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            var response = await _Servico.AtualizarCliente(cliente);
            return Ok(response);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _Servico.ExcluirCliente(id);
            return Ok(response);
        }

    }
}
