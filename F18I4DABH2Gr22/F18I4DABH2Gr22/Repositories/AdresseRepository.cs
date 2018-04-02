using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using HandIn21_Udvidet.Interfaces;

namespace HandIn21_Udvidet.Repositories
{
    public class AdresseRepository : Repository<Adresse>, IAdresseRepository
    {
        public AdresseRepository(DbContext context) : base(context)
        {
        }
    }
}