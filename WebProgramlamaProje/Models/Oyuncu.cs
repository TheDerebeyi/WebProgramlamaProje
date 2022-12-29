using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Oyuncu
    {
        public int OyuncuID { get; set; }
        [Required]
        [Display(Name ="Oyuncu ismi:")]
        public string OyuncuAd { get; set; }
        [Display(Name = "Açıklama:")]
        [MaxLength(400)]
        [Required]
        public string OyuncuDesc { get; set; }
        [Required]
        [Display(Name = "Oyuncu yaşı:")]
        [Range(15,100)]
        public int OyuncuYas { get; set; }
        [ValidateNever]
        public virtual ICollection<FilmOyuncu> Filmler { get; set; }
        
    }
}
