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
    public class EventosController : ControllerBase
    {
        private readonly EventoContext _context;

        public EventosController(EventoContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            var eventos = await _context.Eventos
         .Include(e => e.Actividades)
         .Include(e => e.Inscripciones)
             .ThenInclude(i => i.Participante)
         .Include(e => e.Inscripciones)
             .ThenInclude(i => i.Certificado)
         .Include(e => e.Eventoponentes)
             .ThenInclude(ep => ep.Ponente)
         .ToListAsync();
            return eventos;
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Eventos
        .Include(e => e.Actividades)  // Incluir actividades relacionadas
        .Include(e => e.Inscripciones)  // Incluir inscripciones
            .ThenInclude(i => i.Participante)  // Incluir el participante de cada inscripción
        .Include(e => e.Inscripciones)
            .ThenInclude(i => i.Certificado)  // Incluir el certificado de cada inscripción
        .Include(e => e.Eventoponentes)  // Incluir ponentes asociados al evento
            .ThenInclude(ep => ep.Ponente)  // Incluir los datos del ponente
        .FirstOrDefaultAsync(e => e.Idevento == id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Idevento)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Idevento }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Idevento == id);
        }
    }
}
