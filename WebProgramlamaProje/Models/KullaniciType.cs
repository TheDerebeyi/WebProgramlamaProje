namespace WebProgramlamaProje.Models
{
    public class KullaniciType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Kullanici> Kullanicilar { get; set; }
    }
}
