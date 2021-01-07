using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coursApiRest.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        [HttpGet]
        public List<Contact> Get()
        {
            return Contact.GetContacts();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return Contact.GetContactById(id);
        }

        [HttpGet("search/{search}")]
        public List<Contact> Get(string search)
        {
            return Contact.SearchContacts(search);
        }

        [HttpPost]
        public Contact Post([FromBody]Contact contact)
        {
            contact.Save();
            return contact;
        }

        [HttpPut("{id}")]
        public Contact Put(int id, [FromBody] Contact contact)
        {
            Contact contactExist = Contact.GetContactById(id);
            if(contactExist != null)
            {
                contactExist.Nom = contact.Nom;
                contactExist.Prenom = contact.Prenom;
                contactExist.Telephone = contact.Telephone;
                contactExist.Update();
            }
            return contactExist;
        }

        [HttpDelete("{id}")]
        public Contact Delete(int id)
        {
            Contact contactExist = Contact.GetContactById(id);
            if (contactExist != null)
            {
                contactExist.Remove();
            }
            return contactExist;
        }

    }
}