﻿namespace F18I4DABH2Gr22
{
    public class ErTilknyttet
    {
        protected bool Equals(ErTilknyttet other)
        {
            return Equals(Kontakt, other.Kontakt) && Equals(Adresse, other.Adresse);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ErTilknyttet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Kontakt != null ? Kontakt.GetHashCode() : 0) * 397) ^ (Adresse != null ? Adresse.GetHashCode() : 0);
            }
        }

        public Kontakt Kontakt { get; }
        public Adresse Adresse { get; }
        public string Type { get; set; }

        public ErTilknyttet(string type, Kontakt kontakt, Adresse adresse)
        {
            Type = type;
            Kontakt = kontakt;
            Adresse = adresse;
        }

        public static bool operator == (ErTilknyttet l, ErTilknyttet r)
        {
            return (l.Adresse == r.Adresse && l.Kontakt == r.Kontakt);
        }

        public static bool operator !=(ErTilknyttet l, ErTilknyttet r)
        {
            return (l.Adresse != r.Adresse || l.Kontakt != r.Kontakt);
        }
    }
}