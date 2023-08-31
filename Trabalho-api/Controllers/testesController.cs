using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_api;
using Trabalho_api.Data;

namespace Trabalho_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testesController : ControllerBase
    {
        private readonly Trabalho_apiContext _context;

        public testesController(Trabalho_apiContext context)
        {
            _context = context;
        }

        // GET: api/testes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<teste>>> Getteste()
        {
          if (_context.teste == null)
          {
              return NotFound();
          }
            return await _context.teste.ToListAsync();
        }

        // GET: api/testes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<teste>> Getteste(int id)
        {
          if (_context.teste == null)
          {
              return NotFound();
          }
            var teste = await _context.teste.FindAsync(id);

            if (teste == null)
            {
                return NotFound();
            }

            return teste;
        }

        // PUT: api/testes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putteste(int id, teste teste)
        {
            if (id != teste.id)
            {
                return BadRequest();
            }

            _context.Entry(teste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testeExists(id))
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

        // POST: api/testes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<teste>> Postteste(teste teste)
        {
          if (_context.teste == null)
          {
              return Problem("Entity set 'Trabalho_apiContext.teste'  is null.");
          }
            _context.teste.Add(teste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getteste", new { id = teste.id }, teste);
        }

        // DELETE: api/testes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteteste(int id)
        {
            if (_context.teste == null)
            {
                return NotFound();
            }
            var teste = await _context.teste.FindAsync(id);
            if (teste == null)
            {
                return NotFound();
            }

            _context.teste.Remove(teste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool testeExists(int id)
        {
            return (_context.teste?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
