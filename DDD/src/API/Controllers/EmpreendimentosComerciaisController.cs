using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Domain.Entities;
using Application.DTO;

namespace API.Controllers
{
    [Route("api/Empreendimentos/Comercial")]
    [ApiController]
    public class EmpreendimentosComerciaisController : ControllerBase
    {
        private readonly IEmpreendimentoComercialRepository _Servico;
        public EmpreendimentosComerciaisController(IEmpreendimentoComercialRepository repository)
        {
            _Servico = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Servico.BuscarTodosOsEmpreendimentosComerciais());
        }

        // get id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Servico.BuscarEmpreendimentoComercialPorId(id));
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Post(EmpreendimentoComercialDTO empreendimento)
        {
            var response = await _Servico.AdicionarEmpreendimentoComercial(empreendimento);
            return Ok(response);
        }

        //Put
        [HttpPut]
        public async Task<IActionResult> Put(EmpreendimentoComercial empreendimento)
        {
            var response = await _Servico.AtualizarEmpreendimentoComercial(empreendimento);
            return Ok(response);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _Servico.ExcluirEmpreendimentoComercial(id);
            return Ok(response);
        }

    }
}
