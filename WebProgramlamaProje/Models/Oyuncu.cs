namespace WebProgramlamaProje.Models
{
    public class Oyuncu
    {
        public int OyuncuID { get; set; }
        public string OyuncuAd { get; set; }
        public virtual ICollection<Film> Filmler { get; set; }
        
    }
}
