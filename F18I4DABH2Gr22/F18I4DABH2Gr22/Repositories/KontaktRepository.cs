using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HandIn21.Interfaces;

namespace HandIn21.Repositories
{
    public class KontaktRepository : Repository<Kontakt>, IKontaktRepository
    {
        public KontaktRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ErTilknyttet> GetKontakterWithAddresse(Adresse adresse)
        {
            return _context.Set<ErTilknyttet>().Where(t => t.Adresse.Vejnavn == adresse.Vejnavn).ToList();
        }

        public Kontakt FindKontakt(Expression<Func<Kontakt, bool>> func)
        {
            var kon = _context.Set<Kontakt>().SingleOrDefault<Kontakt>(func);

            _context.Entry(kon).Collection(c => c.Telefonnumre).Load();
            _context.Entry(kon).Collection(c => c._tilknyttedeAdresser).Load();
            return kon;
        }


    }
}