namespace WebProgramlamaProje.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public String FilmAd { get; set; }

        public float FilmPuan { get; set; }

        public List<Oyuncu> Oyuncular { get; set; }

        public Yonetmen Yonetmen { get; set; }

        public List<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
