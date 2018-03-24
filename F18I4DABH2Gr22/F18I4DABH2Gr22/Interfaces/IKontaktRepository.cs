﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn21.Interfaces
{
    interface IKontaktRepository : IRepository<Kontakt>
    {
        Kontakt GetKontaktWithAddresse();
    }
}
