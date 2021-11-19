using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using MediatRSample.Application.Models;
using MediatRSample.Application.Commands;

namespace MediatRSample.Controllers
{
    [ApiController]
    [Route("Produtos")]
    public class ProdutoController: ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutoController (IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraProdutoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraProdutoCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiProdutoCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }

}
