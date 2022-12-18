using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        [Required]
        public string FilmAd { get; set; }

        public float FilmPuan { get; set; }
        public virtual ICollection<Oyuncu> Oyuncular { get; set; }
        public virtual Yonetmen Yonetmen { get; set; }
        public virtual ICollection<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
