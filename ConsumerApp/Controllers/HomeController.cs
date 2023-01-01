using ConsumerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebProgramlamaProje.Models;

namespace ConsumerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Consume(int? id)
        {
            var http = new HttpClient();

            var response = await http.GetAsync("https://localhost:7283/api/FilmApi/"+id);
            var jsondata = await response.Content.ReadAsStringAsync();
            Film? film = JsonConvert.DeserializeObject<Film>(jsondata);
            if (film is null) return NotFound();

            response = await http.GetAsync("https://localhost:7283/api/YonetmenApi/"+film.YonetmenID);
            jsondata = await response.Content.ReadAsStringAsync();
            film.Yonetmen = JsonConvert.DeserializeObject<Yonetmen>(jsondata);
            List<Oyuncu> oyuncular = new List<Oyuncu>();
            if (film.OyuncuID is null) return NotFound();
            foreach(var item in film.OyuncuID) { 
            response = await http.GetAsync("https://localhost:7283/api/OyuncuApi/" + item);
                jsondata = await response.Content.ReadAsStringAsync();
                oyuncular.Add(JsonConvert.DeserializeObject<Oyuncu>(jsondata));
            }
            film.OyuncuList = oyuncular;
            film.FilmPosterUrl = "https://localhost:7283/" + film.FilmPosterUrl;
            return View(film);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}