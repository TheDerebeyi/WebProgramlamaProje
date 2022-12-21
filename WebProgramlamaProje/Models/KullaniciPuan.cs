using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class KullaniciPuan
    {
        public int KullaniciPuanID { get; set; }
        [Required]
        public int Puan { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Film Film { get; set; }

    }
}