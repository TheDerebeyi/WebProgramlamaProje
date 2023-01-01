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
    public class YonetmenApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public YonetmenApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/YonetmenApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yonetmen>>> GetYonetmenler()
        {
            return await _context.Yonetmenler.ToListAsync();
        }

        // GET: api/YonetmenApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Yonetmen>> GetYonetmen(int id)
        {
            var yonetmen = await _context.Yonetmenler.FindAsync(id);

            if (yonetmen == null)
            {
                return NotFound();
            }

            return yonetmen;
        }

        // PUT: api/YonetmenApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYonetmen(int id, Yonetmen yonetmen)
        {
            if (id != yonetmen.YonetmenID)
            {
                return BadRequest();
            }

            _context.Entry(yonetmen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YonetmenExists(id))
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

        // POST: api/YonetmenApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Yonetmen>> PostYonetmen(Yonetmen yonetmen)
        {
            _context.Yonetmenler.Add(yonetmen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYonetmen", new { id = yonetmen.YonetmenID }, yonetmen);
        }

        // DELETE: api/YonetmenApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYonetmen(int id)
        {
            var yonetmen = await _context.Yonetmenler.FindAsync(id);
            if (yonetmen == null)
            {
                return NotFound();
            }

            _context.Yonetmenler.Remove(yonetmen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YonetmenExists(int id)
        {
            return _context.Yonetmenler.Any(e => e.YonetmenID == id);
        }
    }
}
