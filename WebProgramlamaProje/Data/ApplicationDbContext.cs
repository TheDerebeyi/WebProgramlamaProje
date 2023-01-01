using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yonetmen> Yonetmenler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciPuan> KullaniciPuanlar { get; set; }
        public DbSet<FilmOyuncu> FilmOyuncu { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}