using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21_Udvidet
{
    public class Telefonnummer
    {
        public int Id { get; set; }
        public string Nummer { get; set; }
        public string Brug { get; set; }
        public string Teleselskab { get; set; }

        public Telefonnummer(string nummer, string brug, string teleselskab = "")
        {
            Nummer = nummer;
            Brug = brug;
            Teleselskab = teleselskab;
        }

        protected Telefonnummer()
        { }
    }
}