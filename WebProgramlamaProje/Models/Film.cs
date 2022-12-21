using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        [Required]
        [Display(Name = "Başlık:")]
        public string FilmAd { get; set; }
        [Display(Name = "Puan:")]
        public float FilmPuan { get; set; }
        public virtual ICollection<Oyuncu> Oyuncular { get; set; }
        public virtual Yonetmen Yonetmen { get; set; }
        public virtual ICollection<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
