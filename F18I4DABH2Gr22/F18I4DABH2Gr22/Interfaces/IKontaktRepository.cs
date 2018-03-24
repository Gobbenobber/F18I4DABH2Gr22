using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HandIn21.Interfaces
{
    public interface IKontaktRepository : IRepository<Kontakt>
    {
        IEnumerable<ErTilknyttet> GetKontakterWithAddresse(Adresse adresse);
    }
}
