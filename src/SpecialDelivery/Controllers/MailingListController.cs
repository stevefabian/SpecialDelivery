using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecialDelivery.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SpecialDelivery.Controllers
{
    [Route("api/[controller]")]
    public class MailingListController : Controller
    {
        public IMailingListRepository MailingListItems { get; set; }

        public MailingListController(Interfaces.IMailingListRepository mailingListItems)
        {
            MailingListItems = mailingListItems;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Models.MailingList> Get()
        {
            return MailingListItems.GetMailingLists();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetMailingList")]
        public IActionResult GetById(string id)
        {
            var item = MailingListItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Models.MailingList item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            MailingListItems.Add(item);
            return CreatedAtRoute("GetMailingList", new { controller = "MailingList", id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Models.MailingList item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var mlist = MailingListItems.Find(id);
            if (mlist == null)
            {
                return NotFound();
            }

            MailingListItems.Update(item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MailingListItems.Remove(id);
        }
    }
}
