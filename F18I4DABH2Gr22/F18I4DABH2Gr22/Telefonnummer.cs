namespace F18I4DABH2Gr22
{
    public class Telefonnummer
    {
        public string Nummer { get; set; }
        public string Brug { get; set; }
        public string Teleselskab { get; set; }

        public Telefonnummer(string nummer, string brug, string teleselskab = "")
        {
            Nummer = nummer;
            Brug = brug;
            Teleselskab = teleselskab;
        }
    }
}