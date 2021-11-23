﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

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
    }
}
