using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using HandIn21.Interfaces;

namespace HandIn21.Repositories
{
    public class AdresseRepository : Repository<Adresse>, IAdresseRepository
    {
        public AdresseRepository(DbContext context) : base(context)
        {
        }
    }
}