using System;

namespace HandIn21_Udvidet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("JONAS IS RACSST");

            By by = new By
            {
                Land = "Danmark",
                Navn = "Århus C",
                PostNr = "8000"
            };

            Adresse adresse = new Adresse("Nørregade", 42, by);

            Kontakt kontakt = new Kontakt("Patrick", "Gobbenobber", "Budhoo", adresse, new Telefonnummer("28511189", "Privat", "TDC"));

            //Console.WriteLine(kontakt);

            Adresse entilAdresse = new Adresse("Finlandsgade", 22, by);

            kontakt.TilføjAdresse("Universitet", entilAdresse);

            //Console.WriteLine(kontakt);

            using (var pikfuck = new UnitOfWork(new KartotekContext()))
            {
                //pikfuck.Kontakter.Add(kontakt);
                pikfuck.Kontakter.Add(kontakt);

                //var pat = pikfuck.Kontakter.GetKontaktExplicit(k => k.Fornavn == "Patrick");


                pikfuck.Complete();
            }

            Console.WriteLine("Yes!");


        }
    }
}
