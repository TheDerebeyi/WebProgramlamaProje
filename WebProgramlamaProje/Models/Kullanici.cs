using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Password { get; set; }
        public virtual KullaniciType KullaniciType { get; set; }
        public virtual ICollection<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
