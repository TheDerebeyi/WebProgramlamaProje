using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProgramlamaProje.Data;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
using System.Collections.Generic;

namespace WebProgramlamaProje.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class UserController : Controller
    {
        ApplicationDbContext context;
        UserManager<Kullanici> userManager;
        public UserController(ApplicationDbContext _context, UserManager<Kullanici> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        public IActionResult FilmEkle()
        {
            ViewBag.Oyuncular = new SelectList((from s in context.Oyuncular
                                                select new
                                                {
                                                    OyuncuID = s.OyuncuID,
                                                    AdYas = s.OyuncuAd + " (" + s.OyuncuYas + ")"
                                                }), "OyuncuID", "AdYas");
            ViewBag.Yonetmen = new SelectList((from s in context.Yonetmenler
                                               select new
                                               {
                                                   YonetmenID = s.YonetmenID,
                                                   AdYas = s.YonetmenAd + " (" + s.YonetmenYas + ")"
                                               }), "YonetmenID", "AdYas");
            return View();
        }

        public IActionResult FilmSubmit(Film film)
        {
            if (ModelState.IsValid)
            {
                context.Add(film);
                context.SaveChanges();
                foreach (int id in film.OyuncuID.ToList())
                {
                    context.Add(new FilmOyuncu() { FilmID = film.FilmID, OyuncuID = id });
                }
                context.SaveChanges();
                return RedirectToAction("Film", new { id = film.FilmID });
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Film(int? id)
        {
            if (id == null) return NotFound();
            Film film = await context.Filmler.FirstOrDefaultAsync(f => f.FilmID.Equals(id));
            IEnumerable<KullaniciPuan> puanlar = from p in context.KullaniciPuanlar where p.FilmID == id select p;
            float puan = 0.0f;
            foreach (KullaniciPuan p in puanlar)
            {
                puan += p.Puan;
            }
            puan /= puanlar.Count();
            film.FilmPuan = puan;
            if (film is not null)
                return View(film);
            else
                return NotFound();
        }

        public IActionResult OyuncuEkle()
        {
            return View();
        }

        public IActionResult OyuncuSubmit(Oyuncu oyuncu)
        {
            if (ModelState.IsValid)
            {
                context.Add(oyuncu);
                context.SaveChanges();
                return RedirectToAction("Oyuncu", new { id = oyuncu.OyuncuID });
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        public async Task<IActionResult> Oyuncu(int? id)
        {
            Oyuncu oyuncu = await context.Oyuncular.FirstOrDefaultAsync(o => o.OyuncuID.Equals(id));
            if (oyuncu is not null)
                return View(oyuncu);
            else
                return NotFound();
        }

        public IActionResult YonetmenEkle()
        {
            return View();
        }

        public IActionResult YonetmenSubmit(Yonetmen yonetmen)
        {
            if (ModelState.IsValid)
            {
                context.Add(yonetmen);
                context.SaveChanges();
                return RedirectToAction("Yonetmen", new { id = yonetmen.YonetmenID });
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

        public async Task<IActionResult> Yonetmen(int? id)
        {
            if (id == null) return NotFound();
            Yonetmen yonetmen = await context.Yonetmenler.FirstOrDefaultAsync(y => y.YonetmenID.Equals(id));
            if (yonetmen is not null)
                return View(yonetmen);
            else
                return NotFound();
        }

        public IActionResult Puanla(int puan, int filmID)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name);
            string userID = user.Result.Id;
            KullaniciPuan kp = context.KullaniciPuanlar.FirstOrDefault(p => p.KullaniciID.Equals(userID) && p.FilmID.Equals(filmID));
            if (kp is not null)
            {
                kp.Puan = puan;
                context.Update(kp);
            }
            else
            {
                KullaniciPuan kpNew = new KullaniciPuan()
                {
                    FilmID = filmID,
                    KullaniciID = userID,
                    Puan = puan
                };
                context.Add(kpNew);
            }



            context.SaveChanges();

            return RedirectToAction("Film", new { id = filmID });
        }
    }
}
