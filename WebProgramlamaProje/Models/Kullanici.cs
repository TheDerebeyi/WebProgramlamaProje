namespace WebProgramlamaProje.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
        public int KullaniciTypeID { get; set; }
        public List<KullaniciPuan> KullaniciPuan { get; set; }
    }
}
