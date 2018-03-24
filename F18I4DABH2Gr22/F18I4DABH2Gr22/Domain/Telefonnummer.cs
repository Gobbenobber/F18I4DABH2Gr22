using System.ComponentModel.DataAnnotations;

namespace HandIn21
{
    public class Telefonnummer
    {
        [Key]
        public int Nummer { get; set; }
        public string Brug { get; set; }
        public string Teleselskab { get; set; }

        public Telefonnummer(int nummer, string brug, string teleselskab = "")
        {
            Nummer = nummer;
            Brug = brug;
            Teleselskab = teleselskab;
        }
    }
}