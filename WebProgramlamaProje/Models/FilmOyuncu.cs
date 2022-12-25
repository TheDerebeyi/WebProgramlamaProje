namespace WebProgramlamaProje.Models
{
    public class FilmOyuncu
    {
        public int Id { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int OyuncuID { get; set; }
        public Oyuncu Oyuncu { get; set; }
    }
}
