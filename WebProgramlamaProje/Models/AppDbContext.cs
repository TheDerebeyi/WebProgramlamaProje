using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yonetmen> Yonetmenler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=App,Trusted_Connection=True");

        }
    }
}
