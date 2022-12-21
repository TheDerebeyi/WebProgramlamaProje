using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProgramlamaProje.Data;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class UserController : Controller
    {
        ApplicationDbContext context;
        public UserController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult FilmEkle()
        {
            return View();
        }

        public IActionResult OyuncuEkle()
        {
            return View();
        }

        public IActionResult YonetmenEkle()
        {
            return View();
        }
    }
}
