using System.ComponentModel.DataAnnotations;

namespace HandIn21
{
    public class Telefonnummer
    {
        [Key]
        public string Nummer { get; set; }
        public string Brug { get; set; }
        public string Teleselskab { get; set; }

        public Telefonnummer(string nummer, string brug, string teleselskab = "")
        {
            Nummer = nummer;
            Brug = brug;
            Teleselskab = teleselskab;
        }

        public Telefonnummer()
        {

        }
    }
}