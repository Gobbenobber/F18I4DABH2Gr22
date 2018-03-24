using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            return _context.Set<ErTilknyttet>().Where(t => t.Adresse.Equals(adresse)).ToList();
        }
    }
}