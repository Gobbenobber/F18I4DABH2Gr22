using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21
{
    public class ErTilknyttet
    {
        [Key, Column(Order = 0)]
        public int KontaktId { get; set; }

        [Key, Column(Order = 1)]
        public int AdresseId { get; set; }

        [Key, Column(Order = 2)]
        public string Type { get; set; }

        [ForeignKey("KontaktId")]
        public virtual Kontakt Kontakt { get; set; }

        [ForeignKey("AdresseId")]
        public virtual Adresse Adresse { get; set; }

        public ErTilknyttet(string type, Kontakt kontakt, Adresse adresse)
        {
            Type = type;
            Kontakt = kontakt;
            Adresse = adresse;
        }

        protected ErTilknyttet()
        { }
    }
}