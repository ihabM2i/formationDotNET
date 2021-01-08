using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace coursApiRest.Controllers
{
    [Route("api/v1/contacts")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration conf)
        {
            _configuration = conf;
        }

        [HttpGet("testConfig")]
        public string GetConfig()
        {
            return _configuration.GetValue<string>("Logging:LogLevel:Microsoft");
        }

       
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
                contactExist.Nom = contact.Nom != null ? contact.Nom : contactExist.Nom;
                contactExist.Prenom = contact.Prenom != null ? contact.Prenom : contactExist.Prenom;
                contactExist.Telephone = contact.Telephone != null ? contact.Telephone: contactExist.Telephone;
                if(contact.Mails != null && contact.Mails.Count > 0)
                {
                    contactExist.Mails = contact.Mails;
                }
                contactExist.Update();
            }
            return contactExist;
        }

        [HttpPut("{id}/mails")]
        public Email Put(int id, [FromBody]Email mail)
        {
            Contact contactExist = Contact.GetContactById(id);
            if (contactExist != null)
            {
                contactExist.Mails.Add(mail);
                contactExist.Update();
            }
            return mail;
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