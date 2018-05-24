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
using Swashbuckle.Swagger.Annotations;

namespace HandIn3._2.Controllers
{
    public class AdresseController : ApiController
    {
        private readonly IUnitOfWork _uow = new UnitOfWork(new KartotekContext());


        [HttpGet]
        [ResponseType(typeof(IEnumerable<AdresseDto>))]
        public IEnumerable<AdresseDto> GetAdresser()
        {
            var addrs = _uow.Adresser.GetAll().Select(a =>
                new AdresseDto { Id = a.Id, Vejnavn = a.Vejnavn, Husnummer = a.Husnummer });
            return addrs;
        }

        [HttpGet]
        [ResponseType(typeof(FullAdreseeDto))]
        public IHttpActionResult Get(int id)
        {
            var addr = _uow.Adresser.Get(id);
            if (addr == null)
                return NotFound();
            return Ok(FullAdreseeDto.CreateDto(addr));
        }

        // POST: api/Adresse
        [HttpPost]
        [ResponseType(typeof(FullAdreseeDto))]
        public IHttpActionResult Post([FromBody] FullAdreseeDto adresseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addr = FullAdreseeDto.CreateObj(adresseDto);
            var result = _uow.Adresser.Add(addr);

            if (result == null)
                return BadRequest();

            _uow.Complete();
            return CreatedAtRoute("DefaultApi", new { id = addr.Id }, FullAdreseeDto.CreateDto(result));
        }

        // PUT: api/Adresse/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]FullAdreseeDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != value.Id)
                return BadRequest();

            var addr = FullAdreseeDto.CreateObj(value);
            var result = _uow.Adresser.Update(addr);

            if (result == null)
                return BadRequest();

            _uow.Complete();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Adresse/5
        [HttpDelete]
        [ResponseType(typeof(AdresseDto))]
        public IHttpActionResult Delete(int id)
        {
            var result = _uow.Adresser.Delete(id);
            if (result == null)
                return NotFound();

            _uow.Complete();
            return Ok(new AdresseDto { Id = result.Id, Vejnavn = result.Vejnavn, Husnummer = result.Husnummer});
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
