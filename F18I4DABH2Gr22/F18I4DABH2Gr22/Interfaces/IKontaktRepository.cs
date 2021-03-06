﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HandIn21_Udvidet.Interfaces
{
    public interface IKontaktRepository : IRepository<Kontakt, int>
    {
        Kontakt GetKontaktExplicit(Expression<Func<Kontakt, bool>> predicate);
        new Kontakt Add(Kontakt kontakt);

        new Kontakt Update(int id, Kontakt kontakt);
    }
}
