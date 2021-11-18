using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Empreendimentos/Comercial")]
    [ApiController]
    public class EmpreendimentosController2 : ControllerBase {
        private readonly TodoContext _context;
        public EmpreendimentosController2(TodoContext context)
        {
            _context = context;
        }
        // GET: api/Empreendimentos Comerciais 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpreendimentoComercial>>> GetEmpreendimento2()
        {
            return await _context.Empreendimento2.ToListAsync();
        }

        // POST: api/Empreendimentos comerciais 
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpreendimentoMoradia>> PostEmpreendimento(EmpreendimentoComercial empreendimento)
        {
            _context.Empreendimento2.Add(empreendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpreendimento2", new { id = empreendimento.Id }, empreendimento);
        }

        // DELETE: api/Empreendimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpreendimento2(long id)
        {
            var empreendimento = await _context.Empreendimento2.FindAsync(id);
            if (empreendimento == null)
            {
                return NotFound();
            }

            _context.Empreendimento2.Remove(empreendimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpreendimentoExists(long id)
        {
            return _context.Empreendimento2.Any(e => e.Id == id);
        }
    //}

}// Fim classe empreendimentosController

[Route("api/[controller]/Moradia")]
    [ApiController]
    public class EmpreendimentosController : ControllerBase
    {
        private readonly TodoContext _context;

        public EmpreendimentosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Empreendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpreendimentoMoradia>>> GetEmpreendimento()
        {
            return await _context.Empreendimento.ToListAsync();
        }

        // GET: api/Empreendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpreendimentoMoradia>> GetEmpreendimento(long id)
        {
            var empreendimento = await _context.Empreendimento.FindAsync(id);

            if (empreendimento == null)
            {
                return NotFound();
            }

            return empreendimento;
        }

        // PUT: api/Empreendimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpreendimento(long id, EmpreendimentoMoradia empreendimento)
        {
            if (id != empreendimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(empreendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpreendimentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empreendimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpreendimentoMoradia>> PostEmpreendimento(EmpreendimentoMoradia empreendimento)
        {
            _context.Empreendimento.Add(empreendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpreendimento", new { id = empreendimento.Id }, empreendimento);
        }

        // DELETE: api/Empreendimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpreendimento(long id)
        {
            var empreendimento = await _context.Empreendimento.FindAsync(id);
            if (empreendimento == null)
            {
                return NotFound();
            }

            _context.Empreendimento.Remove(empreendimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpreendimentoExists(long id)
        {
            return _context.Empreendimento.Any(e => e.Id == id);
        }
    }


}
