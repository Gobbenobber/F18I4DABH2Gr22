using System.Collections.Generic;
using System.Text;

namespace HandIn21
{
    public class Kontakt
    {
        public string Fornavn { get; private set; }
        public string Mellemnavn { get; private set; }
        public string Efternavn { get; private set; }

        public IReadOnlyList<ErTilknyttet> TilknyttedeAdresser => _tilknyttedeAdresser;

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=======================");
            sb.AppendLine($"{Efternavn}, {Fornavn} {Mellemnavn}:");
            if (Email != ""){ sb.AppendLine($"Email: {Email}");}
            sb.AppendLine("\nTelefonnumre:");
            foreach (var telefonnummer in Telefonnumre)
            {
                sb.AppendLine($"{telefonnummer.Brug}: {telefonnummer.Nummer}" + (telefonnummer.Teleselskab == "" ? "" : $" - {telefonnummer.Teleselskab}"));
            }
            sb.AppendLine("\nAdresser:");
            foreach (var erTilknyttet in _tilknyttedeAdresser)
            {
                sb.AppendLine($"{erTilknyttet.Type}:\n{erTilknyttet.Adresse}");
            }
            sb.Append("=======================");
            return sb.ToString();
        }
    }
}