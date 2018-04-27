using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandIn21.Interfaces;
using HandIn21;
using HandIn3._2.Models;

namespace HandIn3._2.Controllers
{
    public class KontaktController : ApiController
    {
        private IUnitOfWork _uow = new UnitOfWork(new KartotekContext());
        // GET: api/Kontakt

        public IEnumerable<KontaktDto> GetKontakter()
        {
            var kontaktDtoer = _uow.Kontakter.GetAll().Select(k =>
                new KontaktDto () {Id = k.Id, Fornavn = k.Fornavn, Efternavn = k.Efternavn, Mellemnavn = k.Mellemnavn});
            return kontaktDtoer;
        }

        // GET: api/Kontakt/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kontakt
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kontakt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Kontakt/5
        public void Delete(int id)
        {
        }
    }
}
