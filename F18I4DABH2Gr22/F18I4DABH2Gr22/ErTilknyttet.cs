namespace F18I4DABH2Gr22
{
    public class ErTilknyttet
    {
        public Kontakt Kontakt { get; set; }
        public Adresse Adresse { get; set; }
        public string Type { get; set; }

        public ErTilknyttet(string type, Kontakt kontakt, Adresse adresse)
        {
            Type = type;
            Kontakt = kontakt;
            Adresse = adresse;
        }
    }
}