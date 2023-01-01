
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        public AdminController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Panel()
        {

            return View();
        }

        public IActionResult Filmler()
        {
            IEnumerable<Film> filmler = context.Filmler.Include(f => f.Yonetmen);
            return View(filmler);
        }

        public IActionResult Oyuncular()
        {
            IEnumerable<Oyuncu> oyuncular = context.Oyuncular;
            return View(oyuncular);
        }


        public IActionResult Yonetmenler()
        {
            IEnumerable<Yonetmen> yonetmenler = context.Yonetmenler;
            return View(yonetmenler);
        }

        public IActionResult Kullanicilar()
        {
            IEnumerable<Kullanici> kullanicilar = from k in context.Kullanicilar select k;
            foreach (var kullanici in kullanicilar)
            {
                kullanici.Rol = (from r in context.Roles join ur in context.UserRoles on r.Id equals ur.RoleId where ur.UserId == kullanici.Id select r);
            }
            return View(kullanicilar);
        }

        public IActionResult AdminYap(string? id)
        {
            if (id is null) return BadRequest();

            IdentityUserRole<string>? userRole = (from r in context.UserRoles where id == r.UserId select r).FirstOrDefault();
            if (userRole is null) return BadRequest();
            IdentityRole<string>? adminRole = (from a in context.Roles where a.Name == "Admin" select a).FirstOrDefault();
            context.UserRoles.Remove(userRole);
            context.SaveChanges();
            userRole.RoleId = adminRole.Id;
            context.UserRoles.Add(userRole);
            context.SaveChanges();

            return RedirectToAction("Kullanicilar");
        }

        public IActionResult OyuncuSil(int? id)
        {
            Oyuncu? oyuncu = (from o in context.Oyuncular where o.OyuncuID == id select o).FirstOrDefault();
            if (oyuncu is not null)
            {
                context.Remove(oyuncu);
                context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Oyuncular");
        }

        public IActionResult YonetmenSil(int? id)
        {
            Film? film = (from f in context.Filmler where f.YonetmenID == id select f).FirstOrDefault();
            if (film is not null)
            {
                ViewBag.errMsg = "Lütfen önce bu yönetmene ait filmleri silin ya da değiştirin.";
                return View("Yonetmenler", context.Yonetmenler);
            }
            Yonetmen? yonetmen = (from o in context.Yonetmenler where o.YonetmenID == id select o).FirstOrDefault();
            if (yonetmen is not null)
            {
                context.Remove(yonetmen);
                context.SaveChanges();
            }
            return RedirectToAction("Yonetmenler");
        }

        public IActionResult FilmSil(int? id)
        {
            Film? film = (from f in context.Filmler where f.FilmID == id select f).FirstOrDefault();
            if (film is not null)
            {
                context.Remove(film);
                context.SaveChanges();
            }
            return RedirectToAction("Filmler");
        }

        public IActionResult OyuncuEdit(int? id)
        {
            Oyuncu? oyuncu = (from o in context.Oyuncular where o.OyuncuID == id select o).FirstOrDefault();
            if (oyuncu is not null)
            {
                return View(oyuncu);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult OyuncuEditSubmit(Oyuncu? _oyuncu)
        {
            if (_oyuncu is null || !ModelState.IsValid) return BadRequest();
            Oyuncu? oyuncu = (from o in context.Oyuncular where o.OyuncuID == _oyuncu.OyuncuID select o).FirstOrDefault();
            if (oyuncu is not null)
            {
                oyuncu.OyuncuDesc = _oyuncu.OyuncuDesc;
                oyuncu.OyuncuYas = _oyuncu.OyuncuYas;
                oyuncu.OyuncuAd = _oyuncu.OyuncuAd;
                oyuncu.OyuncuCinsiyet = _oyuncu.OyuncuCinsiyet;
                context.Update(oyuncu);
                context.SaveChanges();
                return RedirectToAction("Oyuncular");
            }
            else
            {
                return BadRequest();
            }
        }
        private string FilmUrl(Film film)
        {
            int filmId = film.FilmID;
            var posterImageUrl = "";
            switch (film.FilmTur)
            {
                case "Aksiyon":
                    switch (filmId % 3)
                    {
                        case 0:
                            posterImageUrl = "/img/action1.jpg";
                            break;
                        case 1:
                            posterImageUrl = "/img/action2.jpg";
                            break;
                        case 2:
                            posterImageUrl = "/img/action3.jpg";
                            break;
                    }
                    break;
                case "Bilim Kurgu":
                    switch (filmId % 3)
                    {
                        case 0:
                            posterImageUrl = "/img/sci-fi1.jpg";
                            break;
                        case 1:
                            posterImageUrl = "/img/sci-fi2.jpg";
                            break;
                        case 2:
                            posterImageUrl = "/img/sci-fi3.jpg";
                            break;
                    }
                    break;
                case "Aşk":
                    switch (filmId % 3)
                    {
                        case 0:
                            posterImageUrl = "/img/love1.jpg";
                            break;
                        case 1:
                            posterImageUrl = "/img/love2.jpg";
                            break;
                        case 2:
                            posterImageUrl = "/img/love3.jpg";
                            break;
                    }
                    break;
                case "Korku":
                    switch (filmId % 3)
                    {
                        case 0:
                            posterImageUrl = "/img/horror1.jpg";
                            break;
                        case 1:
                            posterImageUrl = "/img/horror2.jpg";
                            break;
                        case 2:
                            posterImageUrl = "/img/horror3.jpg";
                            break;
                    }
                    break;
            }
            return posterImageUrl;
        }
        public IActionResult FilmEdit(int? id)
        {
            Film? film = (from f in context.Filmler where f.FilmID == id select f).FirstOrDefault();
            if (film is not null)
            {
                ViewBag.Oyuncular = new MultiSelectList((from s in context.Oyuncular
                                                    select new
                                                    {
                                                        OyuncuID = s.OyuncuID,
                                                        AdYas = s.OyuncuAd + " (" + s.OyuncuYas + ")"
                                                    }), "OyuncuID", "AdYas");


                IEnumerable<FilmOyuncu> oyuncular = (from o in context.FilmOyuncu where o.FilmID == film.FilmID select o);

                film.OyuncuID = new List<int>();

                foreach (var item in oyuncular)
                {
                    film.OyuncuID.Add(item.OyuncuID);
                }


                if (film.OyuncuID is not null)
                {
                    foreach (SelectListItem item in ViewBag.Oyuncular)
                    {
                        foreach (var Id in film.OyuncuID)
                        {
                            if (decimal.Parse(item.Value) == Id)
                            {
                                item.Selected = true;
                            }

                        }
                    }
                }
                ViewBag.YonetmenID = new SelectList((from s in context.Yonetmenler
                                                     select new
                                                     {
                                                         YonetmenID = s.YonetmenID,
                                                         AdYas = s.YonetmenAd + " (" + s.YonetmenYas + ")"
                                                     }), "YonetmenID", "AdYas");
                foreach (SelectListItem item in ViewBag.YonetmenID)
                {
                    if (decimal.Parse(item.Value) == film.YonetmenID)
                    {
                        item.Selected = true;
                    }
                }

                return View(film);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult FilmEditSubmit(Film? _film)
        {
            if (_film is null || !ModelState.IsValid) return BadRequest();
            Film? film = (from f in context.Filmler where f.FilmID == _film.FilmID select f).FirstOrDefault();
            if (film is not null)
            {
                film.FilmPosterUrl = FilmUrl(_film);
                film.FilmTur = _film.FilmTur;
                film.FilmCikis = _film.FilmCikis;
                film.FilmAd = _film.FilmAd;
                film.FilmDesc = _film.FilmDesc;
                film.YonetmenID = _film.YonetmenID;

                IEnumerable<FilmOyuncu> oyuncular = (from o in context.FilmOyuncu where o.FilmID == film.FilmID select o);

                film.OyuncuID = new List<int>();
                foreach (var item in oyuncular)
                {
                    film.OyuncuID.Add(item.OyuncuID);
                }

                if (film.OyuncuID is not null)
                {
                    foreach (int id in film.OyuncuID.ToList())
                    {
                        if (!_film.OyuncuID.Contains(id))
                        {
                            FilmOyuncu? oyuncu = (from o in context.FilmOyuncu where id == o.OyuncuID select o).FirstOrDefault();
                            if (oyuncu is not null)
                                context.FilmOyuncu.Remove(oyuncu);
                        }
                    }
                    foreach (int id in _film.OyuncuID)
                    {
                        if (!film.OyuncuID.Contains(id))
                        {
                            context.Add(new FilmOyuncu() { FilmID = film.FilmID, OyuncuID = id });
                        }
                    }
                }
                else
                {
                    foreach (int id in _film.OyuncuID)
                    {

                        context.Add(new FilmOyuncu() { FilmID = film.FilmID, OyuncuID = id });
                    }
                }
                film.OyuncuID = _film.OyuncuID;
                context.Update(film);
                context.SaveChanges();
                return RedirectToAction("Filmler");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult YonetmenEdit(int? id)
        {
            Yonetmen? yonetmen = (from y in context.Yonetmenler where y.YonetmenID == id select y).FirstOrDefault();
            if (yonetmen is not null)
            {
                return View(yonetmen);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult YonetmenEditSubmit(Yonetmen? _yonetmen)
        {
            if (_yonetmen is null) return BadRequest();
            Yonetmen? yonetmen = (from y in context.Yonetmenler where y.YonetmenID == _yonetmen.YonetmenID select y).FirstOrDefault();
            if (yonetmen is not null)
            {
                yonetmen.YonetmenDesc = _yonetmen.YonetmenDesc;
                yonetmen.YonetmenAd = _yonetmen.YonetmenAd;
                yonetmen.YonetmenYas = _yonetmen.YonetmenYas;
                yonetmen.YonetmenCinsiyet = _yonetmen.YonetmenCinsiyet;
                context.Update(yonetmen);
                context.SaveChanges();
                return RedirectToAction("Yonetmenler");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
