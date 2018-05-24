using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HandIn21_Udvidet.Interfaces;

namespace HandIn21_Udvidet.Repositories
{
    public class KontaktRepository : Repository<Kontakt, int>, IKontaktRepository
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

        Kontakt IKontaktRepository.Add(Kontakt kontakt)
        {
            if (_context.Set<Kontakt>().Find(kontakt.Id) != null)
                return null;

            if (Add(kontakt))
                return kontakt;
            return null;
        }



        private new bool Add(Kontakt entity)
        {
            foreach (var tilknyt in entity.TilknyttedeAdresser)
            {
                Adresse addr = null;
                if ((addr = _context.Set<Adresse>().Find(tilknyt.Adresse.Id)) != null)
                {
                    tilknyt.Adresse = addr;
                }
                else
                    return false;
            }

            base.Add(entity);
            return true;
        }

        Kontakt IKontaktRepository.Update(int id, Kontakt kontakt)
        {
            var target = _context.Set<Kontakt>()
                .Include(k => k.TilknyttedeAdresser)
                .Include(k => k.Telefonnumre)
                .SingleOrDefault(k => k.Id == id);

            if (target == null)
                return null;

            foreach (var telefonnummer in target.Telefonnumre)
            {
                _context.Set<Telefonnummer>().Remove(telefonnummer);
            }

            foreach (var telefonnummer in kontakt.Telefonnumre)
            {
                target.Telefonnumre.Add(telefonnummer);
            }

            _context.Entry(target.Telefonnumre).State = EntityState.Modified;

            foreach (var tilknyt in target.TilknyttedeAdresser)
            {
                if (kontakt.TilknyttedeAdresser.Find(t => t.Type == tilknyt.Type) == null)
                {
                    _context.Set<ErTilknyttet>().Remove(tilknyt);
                }
            }

            foreach (var tilknyt in kontakt.TilknyttedeAdresser)
            {
                if (target.TilknyttedeAdresser.Find(t => t.Type == tilknyt.Type) == null)
                {
                    target.TilknyttedeAdresser.Add(tilknyt);
                }
            }

            _context.Entry(target.TilknyttedeAdresser).State = EntityState.Modified;

            target.Fornavn = kontakt.Fornavn;
            target.Mellemnavn = kontakt.Mellemnavn;
            target.Efternavn = kontakt.Efternavn;
            target.Email = kontakt.Email;

            _context.Entry(target).State = EntityState.Modified;

            return target;
        }

        public override void Update(int id, Kontakt kontakt)
        {
            var target = GetKontaktExplicit(k => k.Id == id);
            if (target != null)
            {

                foreach (var prop in target.GetType().GetProperties())
                {
                    var val = prop.GetValue(kontakt);
                    prop.SetValue(target, val);
                }
            }
        }
    }
}