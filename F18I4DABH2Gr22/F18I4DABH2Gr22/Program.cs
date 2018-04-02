using System;

namespace HandIn21_Udvidet
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                By by = new By
                {
                    Land = "Danmark",
                    Navn = "Århus C",
                    PostNr = "8000"
                };

                Adresse adresse = new Adresse("Nørregade", 42, by);

                Kontakt kontakt = new Kontakt("Patrick", "Gobbenobber", "Dankfar", adresse, new Telefonnummer("28511189", "Privat", "TDC"), "Gobbenobber@Dankfar.dk");

                Adresse entilAdresse = new Adresse("Finlandsgade", 22, by);

                kontakt.TilføjAdresse("Universitet", entilAdresse);

                using (var uow = new UnitOfWork(new KartotekContext()))
                {
                    var gobbe = uow.Kontakter.GetKontaktExplicit(k => k.Fornavn == kontakt.Fornavn);

                    if (gobbe == null)
                    {
                        uow.Kontakter.Add(kontakt);
                        uow.Complete();
                    }
                }
            }

            using (var uow = new UnitOfWork(new KartotekContext()))
            {
                var gobbe = uow.Kontakter.GetKontaktExplicit(k => k.Id == 50);

                //Console.ReadKey();
            }


            Console.WriteLine("Yes!");


        }
    }
}
