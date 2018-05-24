using System.Data.Entity;
using HandIn21_Udvidet.Interfaces;

namespace HandIn21_Udvidet.Repositories
{
    public class AdresseRepository : Repository<Adresse, int>, IAdresseRepository
    {
        public AdresseRepository(DbContext context) : base(context)
        {
        }

        public new Adresse Add(Adresse adresse)
        {
            return _context.Set<Adresse>().Add(adresse);
        }

        public Adresse Update(Adresse adresse)
        {
            var target = _context.Set<Adresse>().Find(adresse.Id);
            if (target == null) return null;

            adresse.By.Id = target.By.Id;
            adresse.ById = target.ById;

            _context.Entry(target.By).CurrentValues.SetValues(adresse.By);
            _context.Entry(target).CurrentValues.SetValues(adresse);
            return target;
        }

        public Adresse Delete(int adresseId)
        {
            var target = _context.Set<Adresse>().Find(adresseId);
            if (target == null) return null;
            _context.Entry(target.By).State = EntityState.Deleted;
            _context.Entry(target).State = EntityState.Deleted;
            return target;
        }
    }
}