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
    public class FilmApiController : ControllerBase
    {
        private ApplicationDbContext context;

        public FilmApiController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/FilmApi
        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetFilmler()
        {
            var contextFilm = context.Filmler;
            if (contextFilm is null) return NotFound();
            var filmler = contextFilm.ToList();
            foreach (var film in filmler)
            {
                IEnumerable<FilmOyuncu>? filmOyuncular = from o in context.FilmOyuncu where o.FilmID == film.FilmID select o;
                List<int> oyuncular = new List<int>();
                foreach (var fo in filmOyuncular)
                {
                    Oyuncu? oyuncu = (from o in context.Oyuncular where o.OyuncuID == fo.OyuncuID select o).FirstOrDefault();
                    oyuncular.Add(oyuncu.OyuncuID);
                }
                Yonetmen? yonetmen = (from y in context.Yonetmenler where y.YonetmenID == film.YonetmenID select y).FirstOrDefault();
                if (yonetmen is not null) film.YonetmenID = yonetmen.YonetmenID;
                film.OyuncuID = oyuncular;
            }
            return filmler;
        }

        // GET: api/FilmApi/5
        [HttpGet("{id}")]
        public ActionResult<Film> GetFilm(int id)
        {
            Film? film = (from f in context.Filmler where f.FilmID == id select f).FirstOrDefault();
            if (film is null) return NotFound();

            IEnumerable<FilmOyuncu>? filmOyuncular = from o in context.FilmOyuncu where o.FilmID == film.FilmID select o;
            List<int> oyuncular = new List<int>();
            foreach (var fo in filmOyuncular)
            {
                Oyuncu? oyuncu = (from o in context.Oyuncular where o.OyuncuID == fo.OyuncuID select o).FirstOrDefault();
                oyuncular.Add(oyuncu.OyuncuID);
            }
            Yonetmen? yonetmen = (from y in context.Yonetmenler where y.YonetmenID == film.YonetmenID select y).FirstOrDefault();
            if (yonetmen is not null) film.YonetmenID = yonetmen.YonetmenID;
            film.OyuncuID = oyuncular;
            return film;
        }

        // PUT: api/FilmApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutFilm(int id, Film film)
        {
            if (id != film.FilmID)
            {
                return BadRequest();
            }

            context.Entry(film).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/FilmApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Film> PostFilm(Film film)
        {
            context.Filmler.Add(film);
            context.SaveChanges();

            return CreatedAtAction("GetFilm", new { id = film.FilmID }, film);
        }

        // DELETE: api/FilmApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = context.Filmler.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            context.Filmler.Remove(film);
            context.SaveChanges();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return context.Filmler.Any(e => e.FilmID == id);
        }
    }
}
