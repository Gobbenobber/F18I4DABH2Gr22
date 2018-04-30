using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21_Udvidet
{
    public class ErTilknyttet
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }
        public virtual Adresse Adresse { get; set; }

        public ErTilknyttet(string type, Adresse adresse)
        {
            Type = type;
            Adresse = adresse;
        }

        protected ErTilknyttet()
        { }
    }
}