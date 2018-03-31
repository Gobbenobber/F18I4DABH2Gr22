﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HandIn21
{
    public class Adresse
    {
        public int Id { get; set; }

        public virtual List<ErTilknyttet> TilknyttedeKontakter { get; set; } = new List<ErTilknyttet>();

        public string Vejnavn { get; set; }

        public int Husnummer { get; set; }

        public virtual By By { get; set; }

        public Adresse(string vejnavn, int husnummer, By by)
        {
            Vejnavn = vejnavn;
            Husnummer = husnummer;
            By = by;
        }

        protected Adresse()
        { }

        public void TilføjTilknytning(ErTilknyttet tilknyttet)
        {
            TilknyttedeKontakter.Add(tilknyttet);
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