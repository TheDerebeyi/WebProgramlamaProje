using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            foreach(var kullanici in kullanicilar)
            {
                kullanici.Rol = (from r in context.Roles join ur in context.UserRoles on r.Id equals ur.RoleId where ur.UserId == kullanici.Id select r);
            }
            return View(kullanicilar);
        }

        public IActionResult AdminYap(string? id)
        {
            if(id is null) return BadRequest();

            IdentityUserRole<string> userRole = (from r in context.UserRoles where id == r.UserId select r).First();
            if(userRole is null) return BadRequest();
            IdentityRole<string> adminRole = (from a in context.Roles where a.Name == "Admin" select a).First();
            userRole.RoleId = adminRole.Id;
            context.UserRoles.Update(userRole);
            context.SaveChanges();

            return RedirectToAction("Kullanicilar");
        }

    }
}
