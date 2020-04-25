using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Models;
using diligent_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diligent_backend.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly ContactModel context;

        public ContactController(ContactModel context)
        {
            this.context = context;
        }
        [Route("api/contact")]
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            return this.context.GetContacts().ToArray();
        }

        [Route("api/contact")]
        [HttpPost]
        public void PostContact([FromBody]Contact contact)
        {
            this.context.AddContact(contact);
        }

        [HttpDelete("api/contact/{id}")]
        public void DeleteContact(int id)
        {
            this.context.RemoveContact(id);
        }

    }
}