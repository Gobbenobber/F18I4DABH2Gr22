using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HandIn21
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Fornavn { get; private set; }
        public string Mellemnavn { get; private set; }
        public string Efternavn { get; private set; }

        public List<ErTilknyttet> TilknyttedeAdresser { get; set; } = new List<ErTilknyttet>();
        public List<Telefonnummer> Telefonnumre { get; } = new List<Telefonnummer>();
        public string Email { get; set; }

        public Kontakt(string fornavn, string mellemnavn, string efternavn, Adresse primærAdresse, Telefonnummer telefonnummer,
            string email = "", string adresseType = "Primær Adresse")
        {
            if (fornavn == null || efternavn == null || primærAdresse == null || telefonnummer == null)
                throw new ArgumentNullException();
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Efternavn = efternavn;
            Email = email;
            Telefonnumre.Add(telefonnummer);
            TilføjAdresse(adresseType, primærAdresse);
        }

        protected Kontakt()
        { }

        public void TilføjAdresse(string type, Adresse adresse)
        {
            var tilknytning = new ErTilknyttet(type, this, adresse);
            TilknyttedeAdresser.Add(tilknytning);
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
            foreach (var erTilknyttet in TilknyttedeAdresser)
            {
                sb.AppendLine($"{erTilknyttet.Type}:\n{erTilknyttet.Adresse}");
            }
            sb.Append("=======================");
            return sb.ToString();
        }
    }
}