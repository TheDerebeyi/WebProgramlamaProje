using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=App,Trusted_Connection=True");

        }
    }
}
