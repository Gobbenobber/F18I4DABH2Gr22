using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21
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

        [Key]
        [Column(Order = 0)]
        public virtual Kontakt Kontakt { get; set; }
        [Key]
        [Column(Order = 1)]
        public virtual Adresse Adresse { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Type { get; set; }

        public ErTilknyttet(string type, Kontakt kontakt, Adresse adresse)
        {
            Type = type;
            Kontakt = kontakt;
            Adresse = adresse;
        }

        public ErTilknyttet()
        {

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