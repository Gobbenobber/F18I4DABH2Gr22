using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn21_Udvidet
{
    public class KartotekContext : DbContext
    {

        public KartotekContext()
            : base("name=KartotekContext")
        {
           
        }

        public virtual DbSet<Kontakt> Kontakter { get; set; }
        public virtual DbSet<Adresse> Adresser { get; set; }
        public virtual DbSet<By> Byer { get; set; }
        public virtual DbSet<ErTilknyttet> ErTilknyttet { get; set; }
        public virtual DbSet<Telefonnummer> Telefonnumre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontakt>()
                .HasMany(k => k.Telefonnumre).WithRequired().WillCascadeOnDelete(true);

            modelBuilder.Entity<Kontakt>().
                HasMany(k => k.TilknyttedeAdresser).WithRequired().WillCascadeOnDelete(true);


            

        }
    }
}
