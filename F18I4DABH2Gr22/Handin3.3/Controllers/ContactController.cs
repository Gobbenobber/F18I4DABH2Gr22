using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DocumentDb.Dal;
using DocumentDb.Model;
using Handin3._3.DTO;

namespace Handin3._3.Controllers
{
    public class ContactController : ApiController
    {

        readonly IContactRepository _contactRepository = new ContactRepository();

        // GET: api/Contact
        public async Task<IEnumerable<ContactDto>> Get()
        {
            var items = await _contactRepository.GetItemsAsync(c => c.Id != "");            
            return items.Select(c => new ContactDto()
            {
                Id = c.Id,
                Name = $"{c.FirstName} {c.MiddleName} {c.LastName}",
                Phonenumber = c.Phonenumbers[0].Number
            });
        }

        // GET: api/Contact/5
        public async Task<IHttpActionResult> Get(string id)
        {
            var contact = await _contactRepository.GetItemAsync(id);
            if(contact != null)
                return Ok(contact);
            return BadRequest();
        }

        // POST: api/Contact
        public async Task<IHttpActionResult> Post([FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var target = await _contactRepository.CreateItemAsync(contact);

            if (target == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new {id = target.Id}, target);
        }

        // PUT: api/Contact/5
        public async Task<IHttpActionResult> Put(string id, [FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var target = await _contactRepository.UpdateItemAsync(id, contact);

            if (target == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new {id = target.Id}, target);
        }

        // DELETE: api/Contact/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            var target = await _contactRepository.GetItemAsync(id);

            if (target == null)
                return BadRequest();

            await _contactRepository.DeleteItemAsync(id);
            return Ok();
        }
    }
}
