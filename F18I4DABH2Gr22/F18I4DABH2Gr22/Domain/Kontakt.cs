using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HandIn21_Udvidet
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Fornavn { get;  set; }
        public string Mellemnavn { get;  set; }
        public string Efternavn { get;  set; }

        public List<ErTilknyttet> TilknyttedeAdresser { get; set; } = new List<ErTilknyttet>();
        public List<Telefonnummer> Telefonnumre { get; set; } = new List<Telefonnummer>();
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

        
        public Kontakt()
        { }

        public void TilføjAdresse(string type, Adresse adresse)
        {
            var tilknytning = new ErTilknyttet(type, adresse);
            TilknyttedeAdresser.Add(tilknytning);    
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