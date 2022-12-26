using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models
{
    public class Kullanici : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public virtual ICollection<KullaniciPuan> KullaniciPuan { get; set; }
        [NotMapped]
        public virtual IEnumerable<IdentityRole> Rol { get; set; }
    }
}
