using System;

namespace HandIn21
{
    class Program
    {
        static void Main(string[] args)
        {

            By by = new By
            {
                Land = "Danmark",
                Navn = "Århus C",
                PostNr = "8000"
            };

            Adresse adresse = new Adresse("Nørregade", 44, by);

            Kontakt kontakt = new Kontakt("Patrick", "Gobbenobber", "Budhoo", adresse, new Telefonnummer("28511189", "Privat", "YouSee"), "gobbenobber@gmail.com");

            Console.WriteLine(kontakt);

            Adresse entilAdresse = new Adresse("Finlandsgade", 22, by);

            kontakt.TilføjAdresse("Universitet", entilAdresse);

            Console.WriteLine(kontakt);

        }
    }
}
