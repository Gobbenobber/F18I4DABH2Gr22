using System.Collections.Generic;
using System.Text;

namespace F18I4DABH2Gr22
{
    public class Adresse
    {
        private readonly List<ErTilknyttet> _tilknyttedeKontakter = new List<ErTilknyttet>();

        public IReadOnlyList<ErTilknyttet> TilknyttedeKontakter => _tilknyttedeKontakter;

        public string Vejnavn { get; }
        public int Husnummer { get; }
        public By By { get; }

        public Adresse(string vejnavn, int husnummer, By by)
        {
            Vejnavn = vejnavn;
            Husnummer = husnummer;
            By = by;
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