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
        ClientesController(IClienteService servico) { 
            _Servico= servico;
        }

        [HttpGet]
        public string Get() {
            var Result = _Servico.BuscarTodosOsClientes();
            return "Teste de retorno";   
        }
    }
}
