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
        [Required]
        [Display(Name = "Oyuncu yaşı:")]
        [Range(15,100)]
        public int OyuncuYas { get; set; }
        [ValidateNever]
        public virtual ICollection<FilmOyuncu> Filmler { get; set; }
        
    }
}
