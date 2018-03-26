using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HandIn21
{
    public class Adresse
    {
        private readonly List<ErTilknyttet> _tilknyttedeKontakter = new List<ErTilknyttet>();

        public virtual ICollection<ErTilknyttet> TilknyttedeKontakter => _tilknyttedeKontakter;

        [Key]
        [Column(Order = 0)]
        public string Vejnavn { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Husnummer { get; set; }


        public virtual By By { get; set; }

        public Adresse(string vejnavn, int husnummer, By by)
        {
            Vejnavn = vejnavn;
            Husnummer = husnummer;
            By = by;
        }

        public Adresse()
        {

        }

        public void TilføjTilknytning(ErTilknyttet tilknyttet)
        {
            _tilknyttedeKontakter.Add(tilknyttet);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("----------");
            sb.AppendLine($"{Vejnavn} {Husnummer}");
            sb.AppendLine($"{By.PostNr} {By.Navn}");
            sb.AppendLine($"{By.Land}");
            sb.Append("----------");
            return sb.ToString();
        }
    }
}