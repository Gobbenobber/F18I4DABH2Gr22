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

            var gob = db.GetItems(c => c.MiddleName == "Gobbenobber").ToList()[0];

            gob.Email = "Gobbenobber@Dankfar.dk";

            db.UpdateItem(gob.Id, gob);





        }
    }
}
