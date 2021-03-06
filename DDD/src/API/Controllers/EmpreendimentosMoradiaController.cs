using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Domain.Entities;
using Application.DTO;

namespace API.Controllers
{
    [Route("api/Empreendimentos/Moradia")]
    [ApiController]
    public class EmpreendimentosMoradiaController : ControllerBase
    {
        private readonly IEmpreendimentoMoradiaRepository _Servico;
        public EmpreendimentosMoradiaController(IEmpreendimentoMoradiaRepository repository)
        {
            _Servico = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Servico.BuscarTodosOsEmpreendimentosMoradia());
        }

        // get id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Servico.BuscarEmpreendimentoMoradiaPorId(id));
        }


        //post
        [HttpPost]
        public async Task<IActionResult> Post(EmpreendimentoMoradiaDTO empreendimento)
        {
            var response = await _Servico.AdicionarEmpreendimentoMoradia(empreendimento);
            return Ok(response);
        }

        //Put
        [HttpPut]
        public async Task<IActionResult> Put(EmpreendimentoMoradia empreendimento)
        {
            var response = await _Servico.AtualizarEmpreendimentoMoradia(empreendimento);
            return Ok(response);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _Servico.ExcluirEmpreendimentoMoradia(id);
            return Ok(response);
        }

    }
}
