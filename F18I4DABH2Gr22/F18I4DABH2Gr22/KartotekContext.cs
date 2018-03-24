﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn21
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
    }
}