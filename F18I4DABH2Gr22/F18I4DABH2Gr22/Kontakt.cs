using System.Collections.Generic;

namespace F18I4DABH2Gr22
{
    public class Kontakt
    {
        public string Fornavn { get; private set; }
        public string Mellemnavn { get; private set; }
        public string Efternavn { get; private set; }
        public List<Adresse> Adresser {
            get
            {
                var adresser = new List<Adresse>();
                foreach (var erTilknyttet in _tilknyttedeAdresser)
                {
                    adresser.Add(erTilknyttet.Adresse);
                }

                return adresser;
            }
        }
        private readonly List<ErTilknyttet> _tilknyttedeAdresser = new List<ErTilknyttet>();
        public List<Telefonnummer> Telefonnumre { get; } = new List<Telefonnummer>();
        public string Email { get; set; }

        public Kontakt(string fornavn, string mellemnavn, string efternavn, Adresse primærAdresse, Telefonnummer telefonnummer,
            string email = "", string adresseType = "Primær Adresse")
        {
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Efternavn = efternavn;
            Email = email;
            Telefonnumre.Add(telefonnummer);
            TilføjAdresse(adresseType, primærAdresse);
        }

        public void TilføjAdresse(string type, Adresse adresse)
        {
            var tilknytning = new ErTilknyttet(type, this, adresse);
            _tilknyttedeAdresser.Add(tilknytning);
            adresse.TilføjTilknytning(tilknytning);       
        }

    }
}