using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn21;

namespace F18I4DABH2Gr22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JONAS IS RACSST");

            By by = new By
            {
                Land = "Danmark",
                Navn = "Århus C",
                PostNr = "8000"
            };

            Adresse adresse = new Adresse("Nørregade", 42, by);

            Kontakt kontakt = new Kontakt("Patrick", "Gobbenobber", "Budhoo", adresse, new Telefonnummer(28511189, "Privat", "TDC"));

            Console.WriteLine(kontakt);

            Adresse entilAdresse = new Adresse("Finlandsgade", 22, by);

            kontakt.TilføjAdresse("Universitet", entilAdresse);

            Console.WriteLine(kontakt);

        }
    }
}
