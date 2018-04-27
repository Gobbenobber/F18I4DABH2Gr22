using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn21.Interfaces;
using HandIn21.Repositories;

namespace HandIn21
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KartotekContext _context;

        public UnitOfWork(KartotekContext context)
        {
            _context = context;
            Kontakter = new KontaktRepository(_context);
            Adresser = new AdresseRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IKontaktRepository Kontakter { get; }
        public IAdresseRepository Adresser { get; }

        public int Complete()
        {
           return _context.SaveChanges();
        }

    }
}
