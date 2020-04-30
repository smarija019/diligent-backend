using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Models;
using diligent_backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin, customer")]
        [Route("api/contact")]
        [HttpGet]
        public IEnumerable<ContactForGet> GetContacts()
        {
            return this.context.GetContacts().ToArray();
        }

        [Authorize(Roles = "admin")]
        [Route("api/contact")]
        [HttpPost]
        public void PostContact([FromBody]Contact contact)
        {
            this.context.AddContact(contact);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("api/contact/{id}")]
        public void DeleteContact(int id)
        {
            this.context.RemoveContact(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("api/contact/{id}")]
        public void PutLocation(int id, Contact contact)
        {
            this.context.UpdateContact(id, contact);
        }


    }
}