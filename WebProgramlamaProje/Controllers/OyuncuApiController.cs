using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OyuncuApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OyuncuApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OyuncuApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oyuncu>>> GetOyuncular()
        {
            return await _context.Oyuncular.ToListAsync();
        }

        // GET: api/OyuncuApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oyuncu>> GetOyuncu(int id)
        {
            var oyuncu = await _context.Oyuncular.FindAsync(id);

            if (oyuncu == null)
            {
                return NotFound();
            }

            return oyuncu;
        }

        // PUT: api/OyuncuApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOyuncu(int id, Oyuncu oyuncu)
        {
            if (id != oyuncu.OyuncuID)
            {
                return BadRequest();
            }

            _context.Entry(oyuncu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OyuncuExists(id))
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

        // POST: api/OyuncuApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oyuncu>> PostOyuncu(Oyuncu oyuncu)
        {
            _context.Oyuncular.Add(oyuncu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOyuncu", new { id = oyuncu.OyuncuID }, oyuncu);
        }

        // DELETE: api/OyuncuApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOyuncu(int id)
        {
            var oyuncu = await _context.Oyuncular.FindAsync(id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            _context.Oyuncular.Remove(oyuncu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OyuncuExists(int id)
        {
            return _context.Oyuncular.Any(e => e.OyuncuID == id);
        }
    }
}
