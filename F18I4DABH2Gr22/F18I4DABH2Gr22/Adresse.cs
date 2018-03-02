using System.Collections.Generic;

namespace F18I4DABH2Gr22
{
    public class Adresse
    {
        private readonly List<ErTilknyttet> _tilknyttedeKontakter = new List<ErTilknyttet>();

        public List<Kontakt> Kontakter
        {
            get
            {
                var kontakter = new List<Kontakt>();
                foreach (var kontakt in _tilknyttedeKontakter)
                {
                    kontakter.Add(kontakt.Kontakt);
                }

                return kontakter;
            }
        }

        public string Vejnavn { get; }
        public int Husnummer { get; }

        public Adresse(string vejnavn, int husnummer)
        {
            Vejnavn = vejnavn;
            Husnummer = husnummer;
        }

        public void TilføjTilknytning(ErTilknyttet tilknyttet)
        {
            _tilknyttedeKontakter.Add(tilknyttet);
        }
    }
}