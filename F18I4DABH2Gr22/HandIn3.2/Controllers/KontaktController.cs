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

        [ResponseType(typeof(IEnumerable<KontaktDto>))]
        public IEnumerable<KontaktDto> GetKontakter()
        {
            var kontaktDtoer = _uow.Kontakter.GetAll().Select(k =>
                new KontaktDto () {Id = k.Id, Fornavn = k.Fornavn, Efternavn = k.Efternavn, Mellemnavn = k.Mellemnavn});
            return kontaktDtoer;
        }

        // GET: api/Kontakt/5
        [ResponseType(typeof(FullKontaktDto))]
        public IHttpActionResult Get(int id)
        {
            var kontakt = _uow.Kontakter.GetKontaktExplicit(k => k.Id == id);
            if (kontakt == null)
                return NotFound();
            return Ok(KontaktDtoSkaber.LavEtFullKontaktDto(kontakt));
        }

        // POST: api/Kontakt
        [ResponseType(typeof(FullKontaktDto))]
        public IHttpActionResult Post([FromBody] FullKontaktDto kontakt)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var obj = KontaktDtoSkaber.LavEnKontakt(kontakt);

            var result = _uow.Kontakter.Add(obj);

            if (result == null)
                return BadRequest();

            _uow.Complete();
            return CreatedAtRoute("DefaultApi", new {id = kontakt.Id}, KontaktDtoSkaber.LavEtFullKontaktDto(result));
        }

        // PUT: api/Kontakt/5
        public IHttpActionResult Put(int id, [FromBody]FullKontaktDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != value.Id)
                return BadRequest();

            var obj = KontaktDtoSkaber.LavEnKontakt(value);
            var result = _uow.Kontakter.Update(id, obj);

            if (result == null)
                return BadRequest();

            _uow.Complete();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Kontakt/5
        [ResponseType(typeof(KontaktDto))]
        public IHttpActionResult Delete(int id)
        {
            var kontakt = _uow.Kontakter.GetKontaktExplicit(k => k.Id == id);
            if (kontakt == null)
                return NotFound();

            _uow.Kontakter.Remove(kontakt);
            _uow.Complete();
            return Ok(new KontaktDto { Id = kontakt.Id, Fornavn = kontakt.Fornavn, Efternavn = kontakt.Efternavn, Mellemnavn = kontakt.Mellemnavn });
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
