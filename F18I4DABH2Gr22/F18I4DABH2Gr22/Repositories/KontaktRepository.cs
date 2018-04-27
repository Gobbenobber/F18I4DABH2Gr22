using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HandIn21_Udvidet.Interfaces;

namespace HandIn21_Udvidet.Repositories
{
    public class KontaktRepository : Repository<Kontakt>, IKontaktRepository
    {
        public KontaktRepository(DbContext context) : base(context)
        {
        }

        public Kontakt GetKontaktExplicit(Expression<Func<Kontakt, bool>> predicate)
        {
            var kontakt = _context.Set<Kontakt>().FirstOrDefault(predicate);

            if (kontakt != null)
            {
                _context.Entry(kontakt).Collection(k => k.Telefonnumre).Load();
                _context.Entry(kontakt).Collection(k => k.TilknyttedeAdresser).Load();
            }

            return kontakt;
        }
    }
}