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
    [Route("api/Empreendimentos/Comercial")]
    [ApiController]
    public class EmpreendimentosComerciaisController : ControllerBase
    {
        private readonly IEmpreendimentoComercialService _Servico;
        public EmpreendimentosComerciaisController(IEmpreendimentoComercialService servico)
        {
            _Servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Servico.BuscarTodosOsEmpreendimentosComerciais());
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
