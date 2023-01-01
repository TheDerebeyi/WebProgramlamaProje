using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProgramlamaProje.Models
{
    public class Yonetmen
    {
        public int YonetmenID { get; set; }
        [Required]
        [Display(Name = "Yönetmen ismi:")]
        public string YonetmenAd { get; set; }
        [Display(Name = "Açıklama:")]
        [MaxLength(1000)]
        [Required]
        public string YonetmenDesc { get; set; }
        [Required]
        [Display(Name = "Cinsiyet:")]
        public string YonetmenCinsiyet { get; set; }
        [Required]
        [Display(Name = "Yönetmen yaşı:")]
        [Range(18, 100)]
        public int YonetmenYas { get; set; }

    }
}