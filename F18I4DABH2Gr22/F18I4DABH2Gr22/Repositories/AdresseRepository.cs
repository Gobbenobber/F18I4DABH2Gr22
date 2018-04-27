using System.Data.Entity;
using HandIn21_Udvidet.Interfaces;

namespace HandIn21_Udvidet.Repositories
{
    public class AdresseRepository : Repository<Adresse, int>, IAdresseRepository
    {
        public AdresseRepository(DbContext context) : base(context)
        {
        }
    }
}