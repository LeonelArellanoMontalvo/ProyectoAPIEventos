using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventosAcademicos.Models;
using GestionEventosAcademicos.NewApi.Data;

namespace GestionEventosAcademicos.NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoponentesController : ControllerBase
    {
        private readonly EventoContext _context;

        public EventoponentesController(EventoContext context)
        {
            _context = context;
        }

        // GET: api/Eventoponentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventoponente>>> GetEventoponentes()
        {
            return await _context.Eventoponentes.ToListAsync();
        }

        // GET: api/Eventoponentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventoponente>> GetEventoponente(int id)
        {
            var eventoponente = await _context.Eventoponentes.FindAsync(id);

            if (eventoponente == null)
            {
                return NotFound();
            }

            return eventoponente;
        }

        // PUT: api/Eventoponentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoponente(int id, Eventoponente eventoponente)
        {
            if (id != eventoponente.Idevento)
            {
                return BadRequest();
            }

            _context.Entry(eventoponente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoponenteExists(id))
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

        // POST: api/Eventoponentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eventoponente>> PostEventoponente(Eventoponente eventoponente)
        {
            _context.Eventoponentes.Add(eventoponente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventoponenteExists(eventoponente.Idevento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventoponente", new { id = eventoponente.Idevento }, eventoponente);
        }

        // DELETE: api/Eventoponentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoponente(int id)
        {
            var eventoponente = await _context.Eventoponentes.FindAsync(id);
            if (eventoponente == null)
            {
                return NotFound();
            }

            _context.Eventoponentes.Remove(eventoponente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoponenteExists(int id)
        {
            return _context.Eventoponentes.Any(e => e.Idevento == id);
        }
    }
}
