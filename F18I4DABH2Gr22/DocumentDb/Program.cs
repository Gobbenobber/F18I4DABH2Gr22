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

            var db = new ContactRepository();

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


                db.UpdateItem("Gobbe", gobbenobber);
            }


            Console.ReadKey();





        }
    }
}
