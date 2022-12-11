namespace WebProgramlamaProje.Models
{
    public class Yonetmen
    {
        public int YonetmenID { get; set; }
        public string YonetmenAd { get; set; }
        public List<Film> Filmer { get; set; }

    }
}