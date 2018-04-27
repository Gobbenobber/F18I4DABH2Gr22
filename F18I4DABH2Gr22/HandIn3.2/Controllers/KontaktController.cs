using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HandIn21_Udvidet;
using HandIn21_Udvidet.Interfaces;
using HandIn3._2.Models;

namespace HandIn3._2.Controllers
{
    public class KontaktController : ApiController
    {
        private readonly IUnitOfWork _uow = new UnitOfWork(new KartotekContext());
        // GET: api/Kontakt

        public IEnumerable<KontaktDto> GetKontakter()
        {
            var kontaktDtoer = _uow.Kontakter.GetAll().Select(k =>
                new KontaktDto () {Id = k.Id, Fornavn = k.Fornavn, Efternavn = k.Efternavn, Mellemnavn = k.Mellemnavn});
            return kontaktDtoer;
        }

        // GET: api/Kontakt/5
        [ResponseType(typeof(Kontakt))]
        public IHttpActionResult Get(int id)
        {
            var kontakt = _uow.Kontakter.GetKontaktExplicit(k => k.Id == id);
            if (kontakt == null)
                return NotFound();
            return Ok(kontakt);
        }

        // POST: api/Kontakt
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] Kontakt kontakt)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (_uow.Kontakter.Find(k => k.Id == kontakt.Id).FirstOrDefault() != null)
                return BadRequest();

            foreach (var addr in kontakt.TilknyttedeAdresser)
            {
                if (addr.Adresse.Id != 0)
                {
                    var address = _uow.Adresser.SingleOrDefault(ad => ad.Id == addr.Adresse.Id);

                    if (address != null)
                    {
                        addr.Adresse = address;
                    }
                }
            }

            _uow.Kontakter.Add(kontakt);
            _uow.Complete();
            return CreatedAtRoute("DefaultApi", new {id = kontakt.Id}, kontakt);
        }

        // PUT: api/Kontakt/5
        public IHttpActionResult Put(int id, [FromBody]Kontakt value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != value.Id)
                return BadRequest();

            _uow.Kontakter.Update(id, value);

            _uow.Complete();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Kontakt/5
        public IHttpActionResult Delete(int id)
        {
            var kontakt = _uow.Kontakter.GetKontaktExplicit(k => k.Id == id);
            if (kontakt == null)
                return NotFound();

            _uow.Kontakter.Remove(kontakt);
            _uow.Complete();
            return Ok(kontakt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
