using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDb.Dal;
using DocumentDb.Model;

namespace DocumentDb
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new DocumentDbRepository<Contact>() as IDocumentDbRepository<Contact>;
            
            db.Initialize();

            {
                var city = new City()
                {
                    Country = "Danmark",
                    Name = "Århus",
                    PostalCode = "8000"
                };

                var address = new Address("Nørregade", 42, city);

                var gobbenobber = new Contact("Patrick", "Gobbenobber", "Dankfar", address,
                    new Phonenumber("28511189", "Privat", "TDC"), "Gobbenobber@Dankfar.dk") {Id = "Gobbe"};

                if (db.GetItem(gobbenobber.Id) == null)
                {
                    db.CreateItem(gobbenobber);
                }
            }

            var gob = db.GetItem("Gobbe");

            Console.ReadKey();





        }
    }
}
