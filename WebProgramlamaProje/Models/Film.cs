using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        [Required]
        [Display(Name = "Başlık:")]
        public string FilmAd { get; set; }
        [Display(Name ="Açıklama:")]
        [MaxLength(1000)]
        [Required]
        public string FilmDesc { get; set; }
        [Required]
        public string FilmTur { get; set; }
        [Display(Name = "Puan:")]
        [ValidateNever]
        public float FilmPuan { get; set; }
        [ValidateNever]
        public string FilmPosterUrl { get; set; }
        [Required]
        [Display(Name = "Çıkış Tarihi:")]
        public DateTime FilmCikis { get; set; }
        [Required]
        [Display(Name = "Oyuncular:")]
        [NotMapped]
        public ICollection<int> OyuncuID { get; set; }
        [ValidateNever]
        public ICollection<FilmOyuncu> Oyuncular { get; set; }
        [ValidateNever]
        [NotMapped]
        public ICollection<Oyuncu> OyuncuList { get; set; }
        [Required]
        [Display(Name = "Yönetmen:")]
        public int YonetmenID { get; set; }
        [ValidateNever]
        public virtual Yonetmen Yonetmen { get; set; }
        [ValidateNever]
        public virtual ICollection<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
