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
            var city = new City
            {
                Country = "Denmark",
                Name = "Århus",
                PostalCode = "8000"
            };

            var address = new Address("Oddervej", 61, city);

            var contact = new Contact("Jonas", "Nedergaard", "Andersen", address, new Phonenumber("28189622", "Private"));

            //var converted = contact.ToString();

            var db = new DocumentDbRepository<Contact>() as IDocumentDbRepository<Contact>;
            
            db.Initialize();

            var result = db.GetItemsAsync(c => c.FirstName == "Jonas");
            result.Wait();

            var list = result.Result.ToList();

            if (list.Count != 0)
            {
                Console.WriteLine(list[0].FirstName);
            }

            
            


            
            Console.ReadKey();
        }
    }
}
